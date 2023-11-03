#!/bin/bash

set -e

echo "Building docs..."

git config --global user.email "jonas@dellinger.dev"
git config --global user.name "GH Actions Docs Builder"

cd ./SpotifyAPI.Docs
pnpm i --frozen-lockfile
USE_SSH=true GIT_USER=JohnnyCrazy pnpm run deploy
