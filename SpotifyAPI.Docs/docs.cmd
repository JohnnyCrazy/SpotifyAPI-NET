if "%APPVEYOR_PULL_REQUEST_NUMBER%" == "" (
  echo Building docs...
  pip install mkdocs

  cd ./SpotifyAPI.Docs
  mkdocs build --clean

  mkdir deploy
  cd deploy

  git config --global user.email "johnny@johnnycrazy.de"
  git config --global user.name "AppVeyor Doc Generation"

  git clone --quiet --branch=gh-pages https://%GH_TOKEN%@github.com/JohnnyCrazy/SpotifyAPI-NET gh-pages
  cd gh-pages
  git rm -qrf .
  xcopy ..\..\site .\ /s /e /y
  git add -A
  git commit -m "Built docs | AppVeyor Build %APPVEYOR_BUILD_NUMBER%"
  git push -fq origin gh-pages

  cd ../..
) else (
  echo Skipping doc build
)
