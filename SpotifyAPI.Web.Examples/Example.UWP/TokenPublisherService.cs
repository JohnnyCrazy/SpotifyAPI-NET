using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.UWP
{
  public interface ITokenPublisherService
  {
    event EventHandler<string> TokenReceived;
    void ReceiveToken(Uri uri);
  }
  public class TokenPublisherService : ITokenPublisherService
  {
    public event EventHandler<string> TokenReceived;

    public void ReceiveToken(Uri uri)
    {
      if(string.IsNullOrEmpty(uri.Fragment))
      {
        throw new Exception($"Received weird URI: {uri}");
      }
      var arguments = uri.Fragment.Substring(1).Split("&")
        .Select(param => param.Split("="))
        .ToDictionary(param => param[0], param => param[1]);
      
      if(arguments["access_token"] == null)
      {
        throw new Exception($"No access token found in URI: {uri}");
      }

      TokenReceived?.Invoke(this, arguments["access_token"]);
    }
  }
}
