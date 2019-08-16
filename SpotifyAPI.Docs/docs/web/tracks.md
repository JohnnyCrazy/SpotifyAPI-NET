# Tracks

## GetSeveralTracks

> Get Spotify catalog information for multiple tracks based on their Spotify IDs.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|ids| A list of the Spotify IDs for the tracks. Maximum: 50 IDs. | `new List<String> {"6Y1CLPwYe7zvI8PJiWVz6T"}`
|market| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `"DE"`

Returns a `SeveralTracks` object which has one property, `List<FullTrack> Tracks`

**Usage**
```csharp
SeveralTracks severalTracks = _spotify.GetSeveralTracks(new List<String> {"6Y1CLPwYe7zvI8PJiWVz6T"});
severalTracks.Tracks.ForEach(track => Console.WriteLine(track.Name));
```

---
## GetTrack

> Get Spotify catalog information for a single track identified by its unique Spotify ID.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the track. | `"6Y1CLPwYe7zvI8PJiWVz6T"`
|market| An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking. | `"DE"`

Returns a [FullTrack](https://developer.spotify.com/web-api/object-model/#track-object-full)

**Usage**
```csharp
FullTrack track = _spotify.GetTrack("6Y1CLPwYe7zvI8PJiWVz6T");
Console.WriteLine(track.Name);
```

---
## GetAudioAnalysis

> Get a detailed audio analysis for a single track identified by its unique Spotify ID.

**Parameters**

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|id| The Spotify ID for the track. | `"6Y1CLPwYe7zvI8PJiWVz6T"`

Returns a AudioAnalysis. This object is currently lacking Spotify documentation but archived [EchoNest documentation](https://web.archive.org/web/20160528174915/http://developer.echonest.com/docs/v4/_static/AnalyzeDocumentation.pdf) is relevant.

**Usage**
```csharp
AudioAnalysis analysis = _spotify.GetAudioAnalysis("6Y1CLPwYe7zvI8PJiWVz6T");
Console.WriteLine(analysis.Meta.DetailedStatus);
```
