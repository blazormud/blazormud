#!/bin/zsh

dotnet watch run --project ./src/Server/BlazorMUD.Server.csproj /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
