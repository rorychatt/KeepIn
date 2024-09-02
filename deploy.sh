#!/bin/bash

git pull origin release
kill -9 $(lsof -t -i:5069)
dotnet build -c Release
nohup dotnet run --urls "http://*:5069" > ./logs.txt 2>&1 &
