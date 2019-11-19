# ASP.NET Core Spotify Example

This project provides an example ASP .NET Core Web Application, which utilizes `SpotifyAPI.Web` and `AspNet.Security.OAuth.Spotify` to authenticate the user from Spotify and retrieve his saved library tracks.

## Important files/lines

Most of the important configuration is inside of `Startup.cs`. It reads the `client_id` and `client_secret` from the configration store, so make sure you run the following commands in the project directory:

`dotnet user-secrets set client_secret YOUR_CLIENT_SECRET`
`dotnet user-secrets set client_id YOUR_CLIENT_ID`

Also, it specifies the callback URL (`/callback`). This has to be registered in your Spotify App Settings (`http://localhost:5000/callback`)

The actual request to Spotify and making sure that the user is authenticated happens in `Controllers/HomeController.cs`, which should be self explanatory.
