using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SpotifyAPI.Web.Auth
{
  public static class BrowserUtil
  {
    public static void Open(Uri uri)
    {
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        var uriStr = uri.ToString().Replace("&", "^&");
        Process.Start(new ProcessStartInfo($"cmd", $"/c start {uriStr}"));
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      {
        Process.Start("xdg-open", uri.ToString());
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
      {
        Process.Start("open", uri.ToString());
      }
    }
  }
}
