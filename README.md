# :construction: PRE-ALPHA :construction:

This project has just started and has a long way to go to be useful. Come back later, or contact us if you're interested in contributing to a project like this.

# BlazorMUD

## Tech Stack

- .NET 5
- Blazor
- SignalR
- EF Core

## Project Purposes

- BlazorMUD.Client
  - The Blazor webassembly application that provides the interface the player.
- BlazorMUD.Core
  - Core functionality of BlazorMUD; used by BlazorMUD.Server.
- BlazorMUD.Server
  - Manages the state of the game world. Provides REST endpoints, SignalR hubs, and database connections for the Client.
- BlazorMUD.Shared
  - Code shared between all projects.
