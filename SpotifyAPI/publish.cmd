if "%APPVEYOR_REPO_TAG %" == "true" (
echo Publishing...

cd ./SpotifyAPI

nuget pack ./SpotifyAPI.nuspec -Version %APPVEYOR_REPO_TAG_NAME%
nuget push ./SpotifyAPI-NET.%APPVEYOR_REPO_TAG_NAME%.nupkg -ApiKey %NUGET_TOKEN%
cd ../
) else (
  echo Skipping Publishing
)
