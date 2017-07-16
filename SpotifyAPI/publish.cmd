if "%APPVEYOR_REPO_TAG %" == "true" (
echo Publishing...

cd ./SpotifyAPI

nuget pack -Version %APPVEYOR_REPO_TAG_NAME%

cd ../
) else (
  echo Skipping Publishing
)
