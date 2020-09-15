---
id: logging
title: Logging
---

The library provides a way to inject your own, custom HTTP Logger. By default, no logging is performed.

```csharp
var config = SpotifyClientConfig
  .CreateDefault("YourAccessToken")
  .WithHTTPLogger(new YourHTTPLogger());

var spotify = new SpotifyClient(config);
```

The `IHTTPLogger` interface can be found [here](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Http/Interfaces/IHTTPLogger.cs).

## SimpleConsoleHTTPLogger

The library ships with a simple console-based logger.

```csharp
var config = SpotifyClientConfig
  .CreateDefault("YourAccessToken")
  .WithHTTPLogger(new SimpleConsoleHTTPLogger());

var spotify = new SpotifyClient(config);
```

This logger produces a simple console output for debugging purposes:

```text
GET tracks/NotAnid []
--> BadRequest application/json {  "error" : {    "status" : 400,    "message" : "

GET tracks/6YlOxoHWLjH6uVQvxUIUug []
--> OK application/json {  "album" : {    "album_type" : "album",    "arti
```
