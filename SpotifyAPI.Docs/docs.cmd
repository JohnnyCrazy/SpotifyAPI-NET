if "%APPVEYOR_PULL_REQUEST_NUMBER%" == "" (
  echo Pushing docs...
  pip install mkdocs
  cd ./SpotifyAPI.Docs
  mkdocs build
) else (
  echo Skipping doc build
)
