#!/bin/zsh

dotnet publish ./src/Server/BlazorMUD.Server.csproj /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
