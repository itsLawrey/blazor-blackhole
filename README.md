# BlackHole

> A two-player strategic web-based board game where players sacrifice ships to a central black hole, ported cleanly from WinForms to Blazor WebAssembly.

[![Demo/Live App](https://img.shields.io/badge/Live_Demo-Link-blue)](https://itslawrey-blackhole.web.app/) 

## Visuals

https://github.com/itsLawrey/blazor-blackhole/blob/main/assets/blackhole_compressed.mp4

## Tech Stack

* **Frontend:** Blazor WebAssembly (.NET 8.0)
* **Backend/BaaS:** Firebase Hosting
* **Local Storage:** Architecture includes a persistence layer (`IBlackholeDataAccess`) designed for saving/loading states, planned for future web integration.
* **State Management:** Custom Event-Driven Architecture (C# events observing model changes)
* **Key Libraries:** `Microsoft.AspNetCore.Components.WebAssembly`

## Core Features

* **Dynamic Board Sizes:** Players can choose between 5x5, 7x7, and 9x9 grid configurations to change up the match duration and difficulty on the fly.
* **Click-to-Select Movement System:** You select a ship with a click, and then click in the direction you want it to travel. The ship will slide like a rook until it naturally hits an edge or another ship.
* **Black Hole Mechanics:** A specialized danger zone lies in the center of the board. Any ship that crosses its path gets instantly swallowed and removed from the active game.
* **Automated Win Detection:** The system actively monitors both fleets and immediately ends the game when one player successfully loses more than half of their ships.
* **Live Session Timer:** A built-in timer tracks exactly how long the game has been running, pausing automatically when the game ends.
* **Integrated Tutorial:** A simple collapsible tutorial section is built right into the main page, so players can learn the rules without leaving the active game.

## Technical Architecture & Challenges

### Clean Event-Driven Architecture
The biggest win for this project was porting the core game logic from a desktop WinForms app to a web-based Blazor app without touching the actual game model. I achieved this by keeping the `BlackholeGameModel` completely view-agnostic. It fires off standard C# events like `CellChanged`, `PlayerChanged`, and `GameOver`. The Blazor UI component simply subscribes to these events and calls `StateHasChanged()` whenever something happens, guaranteeing that the business logic and the UI remain totally decoupled.

### Movement Engine and Collision Detection
Since the ships move in a straight line until they hit an obstacle, I had to write a reliable detection logic for all four directions. For example, methods like `ShipPathUp` iterate through the grid ahead of the selected ship to find the closest occupied cell. If the path is clear, the game calculates the furthest boundary edge and updates the ship's coordinate directly, effectively "sliding" it across the array representation of the table in one frame.

### Handling the Central Black Hole
Instead of treating the anomaly as just an empty space, I gave it a specific `CellState.Black` enum. The movement logic constantly checks if a ship's trajectory intersects with this state. If it does, the ship isn't just stopped; the model intercepts the movement and updates the cell to `CellState.None`. Dealing with standard collisions is relatively easy, but making sure the black hole properly swallows ships without throwing array out-of-bounds exceptions took some real careful bounds-checking.

## Installation & Local Setup

If you have the .NET 8 SDK installed, you can spin this up locally in just a few steps.

1. Clone the repository:
   ```bash
   git clone https://github.com/itsLawrey/blazor-blackhole.git
   ```

2. Move into the project directory:
   ```bash
   cd blazor-blackhole
   ```

3. Run the Blazor app:
   ```bash
   dotnet run
   ```

Then, just open `http://localhost:5000` in your browser to play.
