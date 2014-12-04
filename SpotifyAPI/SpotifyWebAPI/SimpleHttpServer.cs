using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Specialized;
using System.Web;

// offered to the public domain for any use with no restriction
// and also with no warranty of any kind, please enjoy. - David Jeske. 

// simple HTTP explanation
// http://www.jmarshall.com/easy/http/

namespace SpotifyAPI.SpotifyWebAPI
{

    public class HttpProcessor {
        public TcpClient socket;        
        public HttpServer srv;

        private Stream inputStream;
        public StreamWriter outputStream;

        public String http_method;
        public String http_url;
        public String http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();


        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public HttpProcessor(TcpClient s, HttpServer srv) {
            this.socket = s;
            this.srv = srv;                   
        }
        

        private string streamReadLine(Stream inputStream) {
            int next_char;
            string data = "";
            while (true) {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }            
            return data;
        }
        public void process() {                        
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET")) {
                    handleGETRequest();
                } else if (http_method.Equals("POST")) {
                    handlePOSTRequest();
                }
            } catch (Exception e) {
                Console.WriteLine("Exception: " + e.ToString());
                writeFailure();
            }
            outputStream.Flush();
            // bs.Flush(); // flush any remaining output
            inputStream = null; outputStream = null; // bs = null;            
            socket.Close();             
        }

        public void parseRequest() {
            String request = streamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length < 2) {
                throw new Exception("invalid http request line");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
        }

        public void readHeaders() {
            String line;
            while ((line = streamReadLine(inputStream)) != null) {
                if (line.Equals("")) {
                    return;
                }
                
                int separator = line.IndexOf(':');
                if (separator == -1) {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' ')) {
                    pos++; // strip any spaces
                }
                    
                string value = line.Substring(pos, line.Length - pos);
                httpHeaders[name] = value;
            }
        }

        public void handleGETRequest() {
            srv.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest() {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            int content_len = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length")) {
                 content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                 if (content_len > MAX_POST_SIZE) {
                     throw new Exception(
                         String.Format("POST Content-Length({0}) too big for this simple server",
                           content_len));
                 }
                 byte[] buf = new byte[BUF_SIZE];              
                 int to_read = content_len;
                 while (to_read > 0) {  

                     int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                     if (numread == 0) {
                         if (to_read == 0) {
                             break;
                         } else {
                             throw new Exception("client disconnected during post");
                         }
                     }
                     to_read -= numread;
                     ms.Write(buf, 0, numread);
                 }
                 ms.Seek(0, SeekOrigin.Begin);
            }
            srv.handlePOSTRequest(this, new StreamReader(ms));

        }

        public void writeSuccess(string content_type="text/html") {
            outputStream.WriteLine("HTTP/1.0 200 OK");            
            outputStream.WriteLine("Content-Type: " + content_type);
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }

        public void writeFailure() {
            outputStream.WriteLine("HTTP/1.0 404 File not found");
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }
    }

    public abstract class HttpServer : IDisposable {

        protected int port;
        TcpListener listener;
        public bool IsActive { get; set; }
       
        public HttpServer(int port) 
        {
            this.IsActive = true;
            this.port = port;
        }

        public void listen()
        {
            try
            {
                listener = new TcpListener(port);
                listener.Start();
                while (IsActive)
                {
                    TcpClient s = listener.AcceptTcpClient();
                    HttpProcessor processor = new HttpProcessor(s, this);
                    Thread thread = new Thread(new ThreadStart(processor.process));
                    thread.Start();
                    Thread.Sleep(1);
                }
            }catch(Exception)
            {
                
            }
        }

        public void Dispose()
        {
            IsActive = false;
            listener.Stop();
        }

        public abstract void handleGETRequest(HttpProcessor p);
        public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
    

}

    public class SimpleHttpServer : HttpServer {

        Action<String, String, String> funcOne;
        Action<String, String, int, String, String> funcTwo;
        AuthType type;
        public SimpleHttpServer(int port, Action<String, String, String> func,AuthType type) : base(port)
        {
            this.funcOne = func;
            this.type = type;
        }
        public SimpleHttpServer(int port, Action<String, String, int, String, String> func, AuthType type) : base(port)
        {
            this.funcTwo = func;
            this.type = type;
        }
        public override void handleGETRequest (HttpProcessor p)
		{
            p.writeSuccess();
            if (p.http_url == "/favicon.ico")
                return;

            
            

            Thread t = null;
            if(type == AuthType.AUTHORIZATION)
            {
                String url = p.http_url;
                url = url.Substring(2, url.Length - 2);
                NameValueCollection col = HttpUtility.ParseQueryString(url);
                if (col.Keys.Get(0) != "code")
                {
                    p.outputStream.WriteLine("<html><body><h1>Spotify Auth canceled!</h1></body></html>");
                    t = new Thread(new ParameterizedThreadStart((o) => { funcOne(null, col.Get(1), col.Get(0)); }));
                }
                else
                {
                    p.outputStream.WriteLine("<html><body><h1>Spotify Auth successful!</h1></body></html>");
                    t = new Thread(new ParameterizedThreadStart((o) => { funcOne(col.Get(0), col.Get(1), null); }));
                }
            }
            else
            {
                if(p.http_url == "/")
                {
                    p.outputStream.WriteLine("<html><body>" +
                    "<script>" +
                    "" +
                    "var hashes = window.location.hash;" +
                    "hashes = hashes.replace('#','&');" +
                    "window.location = hashes" +
                    "</script>" +
                    "<h1>Spotify Auth successful!<br>Please copy the URL and paste it into the application</h1></body></html>");
                    return;
                }
                String url = p.http_url;
                url = url.Substring(2, url.Length - 2);
                NameValueCollection col = HttpUtility.ParseQueryString(url);
                if (col.Keys.Get(0) != "access_token")
                {
                    p.outputStream.WriteLine("<html><body><h1>Spotify Auth canceled!</h1></body></html>");
                    t = new Thread(new ParameterizedThreadStart((o) => { funcTwo(null, null,0,col.Get(1),col.Get(0)); }));
                }
                else
                {
                    p.outputStream.WriteLine("<html><body><h1>Spotify Auth successful!</h1></body></html>");
                    t = new Thread(new ParameterizedThreadStart((o) => { funcTwo(col.Get(0), col.Get(1), Convert.ToInt32(col.Get(2)),col.Get(3),null); }));
                }
            }
            t.Start();
           
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            p.writeSuccess();
        }
    }
    public enum AuthType
    {
        IMPLICIT,AUTHORIZATION
    }
}