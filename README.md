# ⚫ BlackHole

A two-player strategic board game built in **Blazor WebAssembly**. Originally written as a WinForms desktop app for a university assignment, the clean **Model-View** architecture made it surprisingly simple to port the entire game logic to the web without touching a single line of the core game code.

## Game Rules

You and your opponent each command a fleet of ships arranged in an X formation on a grid. In the middle of the board sits a **black hole**. Ships slide across the board like rooks in chess — they keep moving in one direction until they hit another ship or the edge of the board. If a ship flies into the black hole, it's gone forever. The goal is to sacrifice more than half of *your* fleet to the black hole before your opponent does.

## Features

- **Multiple board sizes** — choose between 5×5, 7×7, and 9×9 grids to adjust difficulty and session length
- **Click-to-select movement** — click one of your ships to select it, then click a direction cell to execute the move. Click the same ship again to deselect
- **Black hole mechanics** — ships that collide with or slide into the black hole are permanently removed from the board
- **Turn-based gameplay** — players alternate turns, with the current player clearly highlighted in the status bar
- **Win detection** — the game automatically detects when a player has lost more than half their fleet and declares the winner
- **In-game timer** — a live timer tracks how long the current game has been running and stops when the game ends
- **Collapsible tutorial** — a built-in help section explains the rules without leaving the page
- **Save & Load (WinForms version)** — the persistence layer supports saving and loading game state to/from files, including which ship is currently selected and whose turn it is - coming soon to this version
- **Event-driven architecture** — the game model fires typed C# events (`CellChanged`, `PlayerChanged`, `GameOver`) that the view subscribes to, keeping the model completely view-agnostic

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET 8) |
| Web UI | Blazor WebAssembly |
| Desktop UI (original) | WinForms |
| Hosting | Firebase Hosting |
| Styling | Scoped CSS (`Game.razor.css`) |

## Running locally

```bash
git clone https://github.com/itsLawrey/BlackHole.git
cd BlackHole
dotnet run
```

Then open `http://localhost:5000` in your browser.
