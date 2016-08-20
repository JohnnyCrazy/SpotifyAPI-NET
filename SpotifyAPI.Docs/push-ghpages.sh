#!/bin/bash

if [ "$TRAVIS_PULL_REQUEST" == "false" ]; then

echo Starting push to gh-pages...
mkdir deploy
cd deploy

git config --global user.email "johnny@johnnycrazy.de"
git config --global user.name "Travis-CI"
git clone --quiet --branch=gh-pages https://${GH_TOKEN}@github.com/JohnnyCrazy/SpotifyAPI-NET gh-pages > /dev/null

cd gh-pages
git rm -rf ./ 2> /dev/null
cp -Rf ../../site/* ./
git add -f .
git commit -m "Built mkdocs | Travis Build $TRAVIS_BUILD_NUMBER"
git push -fq origin gh-pages > /dev/null

echo -e "Done"

fi
