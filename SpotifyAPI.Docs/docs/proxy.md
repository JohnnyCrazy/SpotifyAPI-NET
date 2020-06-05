---
id: proxy
title: Proxy
---

import useBaseUrl from '@docusaurus/useBaseUrl';

The included `HTTPClient` has full proxy configuration support:

```csharp
var httpClient = new NetHttpClient(new ProxyConfig("localhost", 8080)
{
  User = "",
  Password = "",
  SkipSSLCheck = false,
});
var config = SpotifyClientConfig
  .CreateDefault()
  .WithHTTPClient(httpClient);

var spotify = new SpotifyClient(config);
```

As an example, [mitmproxy](https://mitmproxy.org/) can be used to inspect the requests and responses:

<img alt="mitmproxy" src={useBaseUrl('img/mitmproxy.png')} />
