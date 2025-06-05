# ByteBike – Retro Write-Bike Rally

A retro-styled 2D side-scrolling bike jumping game built with Unity for Android devices (including Fire tablets).

## Game Overview

ByteBike is an endless runner where players control a bike rider jumping over obstacles, collecting power-ups, and achieving high scores through combo systems and boost mechanics.

## Key Features

- **Physics-based jumping** with double-jump power-ups
- **Boost system** with nitro cans and charge management
- **Obstacle variety**: Ramps, mud pits, oil slicks
- **Power-up system**: Shield stars, double jump tokens, nitro cans
- **Combo scoring** with multiplier system
- **Parallax background** scrolling for depth
- **Pixel-perfect art** style with retro aesthetics
- **Local high score** tracking
- **Google Play Games** integration ready

## Project Setup

### Unity Requirements
- Unity 2021.3 LTS or later
- Android Build Support module
- TextMeshPro package

### Target Platform
- **Primary**: Android 7.0+ (API Level 24) for Fire tablet compatibility
- **Resolution**: 1920×1080 landscape orientation
- **Future**: iOS support planned

### Initial Setup Steps

1. **Open Unity Hub** and create a new 2D project named "ByteBike"
2. **Set Platform**: File → Build Settings → Android → Switch Platform
3. **Configure Player Settings**:
   - Company Name: YourCompany
   - Product Name: ByteBike
   - Package Name: com.yourcompany.ByteBike
   - Default Orientation: Landscape Left
   - Minimum API Level: Android 7.0 (API Level 24)
   - Target API Level: Automatic (Highest Installed)

4. **Import Scripts**: Copy all scripts from `Assets/Scripts/` into your Unity project
5. **Create Folder Structure**: Use the provided folder structure for assets
6. **Setup Scene**: Rename SampleScene to MainScene

## Project Structure

```
Assets/
├── Scripts/
│   ├── PlayerController.cs      # Main player physics and input
│   ├── GameManager.cs           # Game state and scoring
│   ├── ObstacleSpawner.cs       # Spawns obstacles
│   ├── PowerUpSpawner.cs        # Spawns power-ups
│   ├── MoveLeft.cs              # Scrolling movement
│   ├── DestroyOnLeftExit.cs     # Cleanup script
│   ├── ParallaxScroller.cs      # Background scrolling
│   ├── GroundDetector.cs        # Ground collision detection
│   └── AudioManager.cs          # Sound and music management
├── Sprites/
│   ├── Player/
│   │   └── Rider_Idle.png       # 8×8 player sprite
│   ├── Obstacles/
│   │   ├── Ramp.png             # 16×16 triangle ramp
│   │   ├── MudPit.png           # 16×16 mud obstacle
│   │   └── OilSlick.png         # 16×16 oil slick
│   ├── PowerUps/
│   │   ├── NitroCan.png         # 16×16 red canister
│   │   ├── ShieldStar.png       # 16×16 yellow star
│   │   └── DoubleJump.png       # 16×16 green diamond
│   └── BikeSkins/
│       └── Bike_Base.png        # 32×16 main bike sprite
├── Audio/
│   ├── Music/
│   │   └── RetroLoop.mp3        # Background chiptune loop
│   └── SFX/
│       ├── Jump.wav             # Jump sound effect
│       ├── Boost.wav            # Boost activation
│       ├── HitMud.wav           # Mud pit impact
│       └── Pickup.wav           # Power-up collection
├── Scenes/
│   └── MainScene.unity          # Main game scene
└── Prefabs/                     # GameObject prefabs
```

## Scene Setup

### Camera Configuration
- **Main Camera**: Orthographic projection
- **Size**: 5.4 (for 1920×1080 at 16 pixels per unit)
- **Background**: Dark blue solid color
- **Position**: (0, 0, -10)

### Player Setup
1. Create GameObject named "Player"
2. Add `SpriteRenderer` with Bike_Base.png
3. Add `Rigidbody2D` (Dynamic, Gravity Scale: 1.5)
4. Add `BoxCollider2D` matching sprite size
5. Tag as "Player"
6. Attach `PlayerController.cs` script
7. Add `AudioSource` component

### Ground Setup
1. Create ground GameObject with sprite and collider
2. Tag as "Ground"
3. Position at y = -3 approximately

### UI Setup
1. Create Canvas (Screen Space – Overlay)
2. Add Score Text (top-left)
3. Add Boost Gauge Image (top-right)
4. Add Pause Button (top-center)
5. Create Game Over Panel (initially hidden)

## Controls

### Desktop Testing
- **Space**: Jump/Double Jump
- **Left Shift**: Activate Boost (when charged)

### Mobile/Touch
- **Tap**: Jump/Double Jump
- **Two-finger tap**: Activate Boost (when charged)

## Game Mechanics

### Scoring System
- **Base Score**: +10 points per second
- **Ramp Combos**: +50 points per successful ramp
- **Combo Multiplier**: Increases with consecutive ramps
- **High Score**: Stored locally using PlayerPrefs

### Power-Up Effects
- **Nitro Can**: +50% boost charge
- **Shield Star**: 2-second invincibility
- **Double Jump Token**: Enables one mid-air jump

### Obstacle Effects
- **Ramp**: Awards combo points and boost charge if hit correctly
- **Mud Pit**: Slows player for 0.5 seconds
- **Oil Slick**: Breaks combo (unless shielded)

## Development Guidelines

### Art Style
- **Pixel Perfect**: 16 pixels per unit
- **Sprite Import Settings**: Point filtering, no compression
- **Color Palette**: Retro 8-bit inspired colors
- **Animation**: Frame-by-frame pixel art

### Physics Tuning
- **Jump Force**: 5f (adjustable in PlayerController)
- **Boost Force**: 8f (adjustable in PlayerController)
- **Gravity Scale**: 1.5f (adjustable on Rigidbody2D)

### Performance
- **Object Pooling**: Consider for obstacles/power-ups at scale
- **Texture Atlasing**: Combine small sprites for mobile optimization
- **Audio Compression**: Use appropriate formats for mobile

## Build Instructions

### Android Build
1. **File → Build Settings → Android**
2. **Player Settings**:
   - Ensure package name: com.yourcompany.ByteBike
   - Minimum API Level: 24 (Android 7.0)
   - Orientation: Landscape Left
3. **Build**: Create APK or AAB for distribution

### Testing
- **Unity Editor**: Use Space/Shift for desktop testing
- **Android Device**: Test touch controls and performance
- **Fire Tablet**: Verify compatibility and performance

## Future Enhancements

### Phase 2 Features
- **Skin System**: Multiple bike colors/designs
- **More Power-ups**: Speed boost, score multiplier
- **Particle Effects**: Visual feedback for combos
- **Achievement System**: Goals and rewards
- **Daily Challenges**: Rotating objectives

### Platform Expansion
- **iOS**: Port to iPhone/iPad
- **Steam**: Desktop version with keyboard controls
- **Web**: WebGL build for browser play

### Monetization
- **Unity Ads**: Interstitial ads after game over
- **In-App Purchases**: Bike skins, power-up packs
- **Premium Version**: Ad-free experience

## Technical Notes

### Google Play Games Integration
The GameManager includes stub code for Google Play Games Services integration. To enable:

1. Set up Google Play Console project
2. Configure leaderboard IDs
3. Add Google Play Games plugin to Unity
4. Uncomment and configure leaderboard code in GameManager.cs

### Tags Required
Ensure these tags exist in your Unity project:
- Player
- Ground
- MudPit
- OilSlick
- Ramp
- NitroCan
- ShieldStar
- DoubleJumpToken

### Layers (Optional)
Consider setting up layers for:
- Player
- Ground
- Obstacles
- PowerUps
- Background

## Support

For development questions or issues:
1. Check Unity documentation for 2D physics
2. Review PlayerController.cs for gameplay mechanics
3. Test on target Android devices early and often

---

**ByteBike – Retro Write-Bike Rally**  
*Version 1.0 - Development Build* 