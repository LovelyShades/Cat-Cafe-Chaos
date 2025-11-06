🐾 Cat_Cafe_Chaos (Unity Game Demo)

C# Platform Status

A third-person Unity URP simulation game where players manage a bustling cat café filled with curious, mischievous cats.
Serve drinks, pet cats, clean messes, and keep customers happy before the café descends into chaos.

Author: Alanna Matundan
License: MIT License — © 2025 LovelyShades

✨ Features

🐈 Interact with AI-driven cats and customers
☕ Serve drinks and snacks while managing time and cleanliness
🧹 Dynamic “chaos meter” tracking café mess and mood
💰 Earn coins to upgrade furniture and décor
🎥 Cinemachine-based smooth third-person camera
💡 Ambient lighting and mood effects using URP volumes
💬 UI / HUD system with TextMeshPro
🎶 Event-driven audio for footsteps, meows, ambience
💾 GameManager loop controlling score, timers, and round resets

🎬 Showcase

Gameplay Loop
Feed cats → Serve customers → Clean → Upgrade → Repeat

Core Loop Preview
Watch chaos rise as more cats spawn and customers arrive.

UI / HUD System
Displays timers, currency, and café cleanliness indicators.

🧰 Tech Stack

Engine: Unity 2022 LTS (URP)
Language: C# (Single Player)
Packages: Starter Assets Third Person Controller, Cinemachine, TextMeshPro, ProBuilder
Tools: Unity Input System, Animation Controllers, Prefab Workflow
Version Control: Git + GitHub workflow (.gitignore for Unity)

🚀 Getting Started
Prerequisites

Unity 2022 LTS or newer (with URP template support)

Windows / macOS development environment

Git installed

Run Locally
# clone repo
git clone https://github.com/LovelyShades/Cat-Cafe-Chaos.git
cd Cat-Cafe-Chaos

# open in Unity Hub
# select Unity 2022 LTS (URP profile)

Play Mode

Open Scenes/MainScene.unity (or Scenes/CatCafe_Main.unity)

Press ▶ Play in Editor

Use WASD to move / Shift to run / E to interact

📖 Gameplay Overview
Action	Control	Description
Move / Run	WASD + Shift	Navigate café
Interact	E	Pet cat / Serve drink / Clean
Pause Menu	Esc	Open HUD menu
Camera Control	Mouse	Cinemachine orbit and follow
🧱 Project Structure
Cat-Cafe-Chaos/
│
├─ Assets/
│  ├─ Scenes/               # main game and UI scenes
│  ├─ Scripts/              # gameplay logic (C#, AI, manager)
│  ├─ Prefabs/              # reusable objects (player, cats, UI)
│  ├─ Animations/           # controller animations + states
│  ├─ Materials/ & Models/  # 3D assets + textures
│  └─ Audio/                # sound FX and music
│
├─ Packages/                # Unity packages manifest
├─ ProjectSettings/         # URP + input configuration
└─ README.md

📚 What I Learned

Implementing third-person movement with Starter Assets + Cinemachine

Building a looping GameManager system for state control

Creating responsive UI layouts with TextMeshPro and Canvas Groups

Optimizing lighting and post-processing for URP

Designing AI behaviors using NavMesh and scriptable patterns

Managing Git version control for large Unity projects

🛣️ Future Improvements

Save / Load progress system

Customer queue AI logic improvements

Café upgrade shop UI and decor expansion

Day / Night cycle and lighting transitions

Polish animations and sound mix

Public itch.io build demo

📜 License

Licensed under the MIT License.
© 2025 Alanna Matundan (LovelyShades).
