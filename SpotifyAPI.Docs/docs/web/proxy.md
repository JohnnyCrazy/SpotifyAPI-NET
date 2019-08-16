---
sidebar: false
---

# Proxy Settings

You can forward your proxy settings to the web api by using a field in the `SpotifyLocalAPIConfig`.

```csharp
ProxyConfig proxyConfig = new ProxyConfig()
{
    Host = "127.0.0.1",
    Port = 8080
    // Additional values like Username and Password are available
};

SpotifyWebAPI api = new SpotifyWebAPI(proxyConfig);
```
