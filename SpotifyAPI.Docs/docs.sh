#!/bin/bash

set -e

echo "Building docs..."

git config --global user.email "jonas@dellinger.dev"
git config --global user.name "GH Actions Docs Builder"

cd ./SpotifyAPI.Docs
yarn
USE_SSH=true GIT_USER=JohnnyCrazy yarn deploy
