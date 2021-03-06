# Rabbit Rush Endless Runner

## [Unreleased]


## [1.0.0] - 1/9/2020

### Added
- High Score: Storing, Viewing and Reseting
- Increase Difficulty with Score gained
  - Added Speed Mofifier based on Difficulty that affect every Values in the game (Obstacles, Collectibles and Background SPeeds)

### Fixed
- Scrolling Background, Basic Collectibles and Obstacles now Move at the Same Speed as each others
- Scrolling Background is now fully repeated and compatible with Sprite Renderer
- Broken Layouts no longer make things visible outside of Camera View


## [Prototype 4] - 24/8/2020

### Added
- Mobile Supports
  - Touch Inputs: Swiping to Move
  - Remote Developer Settings
  - UI Pause Button
- Pixel Perfect Sprites and Quality Settings

### Fixed
- DIabled Movements on Game Over


## [Prototype 3] - 16/8/2020

### Added
- High Score: Reset in Main Menu
- Game Over Menu showing Score
- Pausing and Unpausing with Menu
- Menu and Button Tooltips
- Pixel Arts Intergrations
  - Pixelated Font
  - Running Lane
  - Visual Effects

### Changed
- Tweak the Move Speed of Obstacles
- Updated the Arts and Layouts of the Play Scene

### Fixed
- Fixed when Score doesn't reset on new playthrough
- Fixed wrongly Looped animations


## [Prototype 2] - 21/4/2020

### Added
- Scoring SYstem and Score UI
- Player's Animations: Starting + Running and Dying
- Added Start Delays to Spawner and Score Counter
- Added UI for In-game Information

### Changed
- Break the Player Script into Status and Snap Movement Controller seperatedly


## [Gameplay Prototype] - 13/4/2020

### Added
- Player Controls: Up-down Fixed Movements (Fixed Time step Overriding) and Clamping
- Obstacles: Player dies if Collide with Obstacles
- Spawning Obstacles
  - Spawn Points
  - Spawn Patterns
  - SPawn with Interval
- Game Over
  - When Player dies
  - Stop all Obstacle Movement
  - Show Game Over UI
  - Restart
  - Return to Menu
- Main Menu Scene
  - Play
  - Quit
- Cleaning up: 
  - Wall to Destroy everything moved offscreen
  - Self Clean: Spawn points and Spawn Patterns will destroyed themselves overtime