using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;

// offered to the public domain for any use with no restriction
// and also with no warranty of any kind, please enjoy. - David Jeske.

// simple HTTP explanation
// http://www.jmarshall.com/easy/http/

namespace SpotifyAPI.Web
{
    public class HttpProcessor : IDisposable
    {
        private const int MaxPostSize = 10 * 1024 * 1024; // 10MB
        private const int BufSize = 4096;
        private readonly HttpServer _srv;
        private Stream _inputStream;
        public Hashtable HttpHeaders = new Hashtable();
        public string HttpMethod;
        public string HttpProtocolVersionstring;
        public string HttpUrl;
        public StreamWriter OutputStream;
        private bool _isActive = true;

        public HttpProcessor(HttpServer srv)
        {
            _srv = srv;
        }

        private string StreamReadLine(Stream inputStream)
        {
            string data = "";
            while (_isActive)
            {
                var nextChar = inputStream.ReadByte();
                if (nextChar == '\n')
                {
                    break;
                }
                if (nextChar == '\r')
                {
                    continue;
                }
                if (nextChar == -1)
                {
                    Thread.Sleep(1);
                    continue;
                }
                data += Convert.ToChar(nextChar);
            }
            return data;
        }

        public void Process(object tcpClient)
        {
            TcpClient socket = tcpClient as TcpClient;
            
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            _inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            OutputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try
            {
                ParseRequest();
                ReadHeaders();
                if (HttpMethod.Equals("GET"))
                {
                    HandleGetRequest();
                }
                else if (HttpMethod.Equals("POST"))
                {
                    HandlePostRequest();
                }
            }
            catch
            {
                WriteFailure();
            }
            OutputStream.Flush();
            _inputStream = null;
            OutputStream = null;
            socket.Close();
        }

        public void ParseRequest()
        {
            string request = StreamReadLine(_inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length < 2)
            {
                throw new Exception("Invalid HTTP request line");
            }
            HttpMethod = tokens[0].ToUpper();
            HttpUrl = tokens[1];
        }

        public void ReadHeaders()
        {
            string line;
            while ((line = StreamReadLine(_inputStream)) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("Invalid HTTP header line: " + line);
                }
                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                HttpHeaders[name] = value;
            }
        }

        public void HandleGetRequest()
        {
            _srv.HandleGetRequest(this);
        }

        public void HandlePostRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream
            // we hand him needs to let him see the "end of the stream" at this content
            // length, because otherwise he won't know when he's seen it all!

            MemoryStream ms = new MemoryStream();
            if (HttpHeaders.ContainsKey("Content-Length"))
            {
                var contentLen = Convert.ToInt32(HttpHeaders["Content-Length"]);
                if (contentLen > MaxPostSize)
                {
                    throw new Exception($"POST Content-Length({contentLen}) too big for this simple server");
                }
                byte[] buf = new byte[BufSize];
                int toRead = contentLen;
                while (toRead > 0)
                {
                    int numread = _inputStream.Read(buf, 0, Math.Min(BufSize, toRead));
                    if (numread == 0)
                    {
                        if (toRead == 0)
                        {
                            break;
                        }
                        throw new Exception("Client disconnected during post");
                    }
                    toRead -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            _srv.HandlePostRequest(this, new StreamReader(ms));
        }

        public void WriteSuccess(string contentType = "text/html")
        {
            OutputStream.WriteLine("HTTP/1.0 200 OK");
            OutputStream.WriteLine("Content-Type: " + contentType);
            OutputStream.WriteLine("Connection: close");
            OutputStream.WriteLine("");
        }

        public void WriteFailure()
        {
            OutputStream.WriteLine("HTTP/1.0 404 File not found");
            OutputStream.WriteLine("Connection: close");
            OutputStream.WriteLine("");
        }

        public void Dispose()
        {
            _isActive = false;
        }
    }

    public abstract class HttpServer : IDisposable
    {
        private TcpListener _listener;
        protected int Port;

        protected HttpServer(int port)
        {
            IsActive = true;
            Port = port;
        }

        public bool IsActive { get; set; }

        public void Dispose()
        {
            IsActive = false;
            _listener.Stop();
            GC.SuppressFinalize(this);
        }

        public void Listen()
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, Port);
                _listener.Start();

                using (HttpProcessor processor = new HttpProcessor(this))
                {
                    while (IsActive)
                    {
                        TcpClient s = _listener.AcceptTcpClient();
                        Thread thread = new Thread(processor.Process);
                        thread.Start(s);
                        Thread.Sleep(1);
                    }
                }
            }
            catch (SocketException e)
            {
                if (e.ErrorCode != 10004) //Ignore 10004, which is thrown when the thread gets terminated
                    throw;
            }
        }

        public abstract void HandleGetRequest(HttpProcessor p);

        public abstract void HandlePostRequest(HttpProcessor p, StreamReader inputData);
    }

    public class AuthEventArgs
    {
        //Code can be an AccessToken or an Exchange Code
        public string Code { get; set; }

        public string TokenType { get; set; }
        public string State { get; set; }
        public string Error { get; set; }
        public int ExpiresIn { get; set; }
    }

    public class SimpleHttpServer : HttpServer
    {
        private readonly AuthType _type;

        public delegate void AuthEventHandler(AuthEventArgs e);

        public event AuthEventHandler OnAuth;

        public SimpleHttpServer(int port, AuthType type) : base(port)
        {
            _type = type;
        }

        public override void HandleGetRequest(HttpProcessor p)
        {
            p.WriteSuccess();
            if (p.HttpUrl == "/favicon.ico")
                return;

            Thread t;
            if (_type == AuthType.Authorization)
            {
                string url = p.HttpUrl;
                url = url.Substring(2, url.Length - 2);
                NameValueCollection col = HttpUtility.ParseQueryString(url);
                if (col.Keys.Get(0) != "code")
                {
                    p.OutputStream.WriteLine("<html><body><h1>Spotify Auth canceled!</h1></body></html>");
                    t = new Thread(o =>
                    {
                        OnAuth?.Invoke(new AuthEventArgs()
                        {
                            State = col.Get(1),
                            Error = col.Get(0),
                        });
                    });
                }
                else
                {
                    p.OutputStream.WriteLine("<html><body><h1>Spotify Auth successful!</h1><script>window.close();</script></body></html>");
                    t = new Thread(o =>
                    {
                        OnAuth?.Invoke(new AuthEventArgs()
                        {
                            Code = col.Get(0),
                            State = col.Get(1)
                        });
                    });
                }
            }
            else
            {
                if (p.HttpUrl == "/")
                {
                    p.OutputStream.WriteLine("<html><body>" +
                                             "<script>" +
                                             "" +
                                             "var hashes = window.location.hash;" +
                                             "hashes = hashes.replace('#','&');" +
                                             "window.location = hashes" +
                                             "</script>" +
                                             "<h1>Spotify Auth successful!<br>Please copy the URL and paste it into the application</h1></body></html>");
                    return;
                }
                string url = p.HttpUrl;
                url = url.Substring(2, url.Length - 2);
                NameValueCollection col = HttpUtility.ParseQueryString(url);
                if (col.Keys.Get(0) != "access_token")
                {
                    p.OutputStream.WriteLine("<html><body><h1>Spotify Auth canceled!</h1></body></html>");
                    t = new Thread(o =>
                    {
                        OnAuth?.Invoke(new AuthEventArgs()
                        {
                            Error = col.Get(0),
                            State = col.Get(1)
                        });
                    });
                }
                else
                {
                    p.OutputStream.WriteLine("<html><body><h1>Spotify Auth successful!</h1><script>window.close();</script></body></html>");
                    t = new Thread(o =>
                    {
                        OnAuth?.Invoke(new AuthEventArgs()
                        {
                            Code = col.Get(0),
                            TokenType = col.Get(1),
                            ExpiresIn = Convert.ToInt32(col.Get(2)),
                            State = col.Get(3)
                        });
                    });
                }
            }
            t.Start();
        }

        public override void HandlePostRequest(HttpProcessor p, StreamReader inputData)
        {
            p.WriteSuccess();
        }
    }

    public enum AuthType
    {
        Implicit,
        Authorization
    }
}