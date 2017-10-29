#!/bin/bash

dotnet restore NetInfo_netcore.csproj

dotnet build NetInfo_netcore.csproj

dotnet publish NetInfo_netcore.csproj -c Release -r win-x64
dotnet publish NetInfo_netcore.csproj -c Release -r win-x86
dotnet publish NetInfo_netcore.csproj -c Release -r osx.10.12-x64
dotnet publish NetInfo_netcore.csproj -c Release -r linux-x64