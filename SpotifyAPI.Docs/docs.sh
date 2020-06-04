#!/bin/bash

set -e

if [ -z "$APPVEYOR_PULL_REQUEST_NUMBER" ]; then
  if [ "$APPVEYOR_REPO_BRANCH" = "master" ]; then
    echo "Building docs..."

    echo "$GH_DEPLOY_TOKEN" | base64 -d > "$HOME/.ssh/id_rsa"
    chmod 700 ~/.ssh
    chmod 600 ~/.ssh/id_rsa

    git config --global user.email "jonas@dellinger.dev"
    git config --global user.name "AppVeyor Docs Builder"

    cd ./SpotifyAPI.Docs
    yarn
    USE_SSH=true GIT_USER=JohnnyCrazy yarn deploy
  fi
fi
