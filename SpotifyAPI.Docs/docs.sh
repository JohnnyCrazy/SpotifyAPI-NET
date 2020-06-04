#!/bin/bash

if [ -z "$APPVEYOR_PULL_REQUEST_NUMBER" ]; then
  if [ "$APPVEYOR_REPO_BRANCH" = "master" ]; then
    echo "Building docs..."
    nvm alias default 14.3.0

    echo "$GH_DEPLOY_TOKEN" | base64 -d > "$HOME/.ssh/id_rsa"

    cd ./SpotifyAPI.Docs
    yarn
    USE_SSH=true GIT_USER=JohnnyCrazy yarn deploy
  fi
fi
