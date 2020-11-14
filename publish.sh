#!/bin/bash

set -e

echo "Publishing..."

cd ./SpotifyAPI.Web
dotnet pack -c Release SpotifyAPI.Web.csproj -p:PackageVersion="$RELEASE_VERSION"
nuget push "./bin/Release/SpotifyAPI.Web.$RELEASE_VERSION.nupkg"\
  -ApiKey "$NUGET_TOKEN"\
  -NonInteractive\
  -Source https://www.nuget.org/api/v2/package

cd ../SpotifyAPI.Web.Auth
dotnet pack -c Release SpotifyAPI.Web.Auth.csproj -p:PackageVersion="$RELEASE_VERSION"
nuget push "./bin/Release/SpotifyAPI.Web.Auth.$RELEASE_VERSION.nupkg"\
  -ApiKey "$NUGET_TOKEN"\
  -NonInteractive\
  -Source https://www.nuget.org/api/v2/package

cd ..
