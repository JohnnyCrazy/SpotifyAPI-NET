if "%APPVEYOR_PULL_REQUEST_NUMBER%" == "" (
  echo Building docs...
  pip install mkdocs
  cd ./SpotifyAPI.Docs
  mkdocs build
  cd ..
) else (
  echo Skipping doc build
)
