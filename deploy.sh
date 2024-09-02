#!/bin/bash
cd /git/rorychatt/KeepIn
git pull origin release
kill -9 $(lsof -t -i:5069)
dotnet build -c Release
nohup dotnet run --urls "http://*:5069" > /git/rorychatt/KeepIn/logs.txt 2>&1 &
