#!/bin/bash

set -e

echo "Building docs..."

echo "$GH_DEPLOY_TOKEN" | base64 -d > "$HOME/.ssh/id_rsa"
chmod 700 ~/.ssh
chmod 600 ~/.ssh/id_rsa

git config --global user.email "jonas@dellinger.dev"
git config --global user.name "GH Actions Docs Builder"

cd ./SpotifyAPI.Docs
yarn
USE_SSH=true GIT_USER=JohnnyCrazy yarn deploy
