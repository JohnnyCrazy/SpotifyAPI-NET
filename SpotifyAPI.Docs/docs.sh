#!/bin/bash

set -e

echo "Building docs..."

export LATEST_VERSION="$(git tag --sort=committerdate | grep -E '[0-9]' | tail -1)"

echo "Set LATEST_VERSION to ${LATEST_VERSION}"

git config --global user.email "jonas@dellinger.dev"
git config --global user.name "GH Actions Docs Builder"

cd ./SpotifyAPI.Docs
pnpm i --frozen-lockfile

USE_SSH=true GIT_USER=JohnnyCrazy pnpm run deploy
