if "%APPVEYOR_REPO_TAG%" == "true" (

echo Publishing...

cd ./SpotifyAPI.Web
nuget pack ./SpotifyAPI.Web.nuspec -Version %APPVEYOR_REPO_TAG_NAME%
nuget push ./SpotifyAPI.Web.%APPVEYOR_REPO_TAG_NAME%.nupkg -ApiKey %NUGET_TOKEN% -NonInteractive -Source https://www.nuget.org/api/v2/package

cd ../SpotifyAPI.Web.Auth
nuget pack ./SpotifyAPI.Web.Auth.nuspec -Version %APPVEYOR_REPO_TAG_NAME%
nuget push ./SpotifyAPI.Web.Auth.%APPVEYOR_REPO_TAG_NAME%.nupkg -ApiKey %NUGET_TOKEN% -NonInteractive -Source https://www.nuget.org/api/v2/package

) else (
  echo Skipping Publishing
)
