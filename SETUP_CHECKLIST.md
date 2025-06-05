# ByteBike Setup Checklist

Follow this checklist to get ByteBike up and running in Unity.

## ✅ Prerequisites

- [ ] Unity 2021.3 LTS or later installed
- [ ] Android Build Support module installed
- [ ] Android SDK configured in Unity

## ✅ Project Creation

- [ ] Create new Unity 2D project named "ByteBike"
- [ ] Switch platform to Android (File → Build Settings → Android → Switch Platform)
- [ ] Import all scripts from the provided Assets/Scripts/ folder
- [ ] Create the folder structure as outlined in README.md

## ✅ Player Settings Configuration

- [ ] Set Company Name: "YourCompany"
- [ ] Set Product Name: "ByteBike"
- [ ] Set Package Name: "com.yourcompany.ByteBike"
- [ ] Set Default Orientation: Landscape Left
- [ ] Set Minimum API Level: Android 7.0 (API Level 24)
- [ ] Set resolution: 1920×1080

## ✅ Scene Setup

- [ ] Rename "SampleScene" to "MainScene"
- [ ] Configure Main Camera:
  - [ ] Set to Orthographic
  - [ ] Set size to 5.4
  - [ ] Set background to dark blue
  - [ ] Position at (0, 0, -10)

## ✅ Required Tags Creation

Create these tags in Unity (Tags & Layers):
- [ ] Player
- [ ] Ground  
- [ ] MudPit
- [ ] OilSlick
- [ ] Ramp
- [ ] NitroCan
- [ ] ShieldStar
- [ ] DoubleJumpToken

## ✅ Placeholder Assets

Create or obtain these sprite assets (see Assets/Sprites/placeholder_instructions.txt):
- [ ] Rider_Idle.png (8×8)
- [ ] Bike_Base.png (32×16)
- [ ] Ramp.png (16×16)
- [ ] MudPit.png (16×16)
- [ ] OilSlick.png (16×16)
- [ ] NitroCan.png (16×16)
- [ ] ShieldStar.png (16×16)
- [ ] DoubleJump.png (16×16)

For each sprite:
- [ ] Set Pixels Per Unit: 16
- [ ] Set Filter Mode: Point (no filter)
- [ ] Set Compression: None

## ✅ Audio Assets

Create or obtain these audio files:
- [ ] RetroLoop.mp3 (background music)
- [ ] Jump.wav
- [ ] Boost.wav  
- [ ] HitMud.wav
- [ ] Pickup.wav

## ✅ GameObjects Setup

### Player GameObject
- [ ] Create GameObject named "Player"
- [ ] Add SpriteRenderer with Bike_Base.png
- [ ] Add Rigidbody2D (Dynamic, Gravity Scale: 1.5)
- [ ] Add BoxCollider2D
- [ ] Set tag to "Player"
- [ ] Attach PlayerController.cs script
- [ ] Add AudioSource component
- [ ] Position at (0, 0, 0)

### Ground GameObject
- [ ] Create GameObject named "Ground"
- [ ] Add SpriteRenderer with ground sprite/color
- [ ] Add BoxCollider2D
- [ ] Set tag to "Ground"
- [ ] Position at (0, -3, 0)
- [ ] Scale appropriately for screen width

### Game Manager
- [ ] Create empty GameObject named "GameManager"
- [ ] Attach GameManager.cs script
- [ ] Add AudioSource component

### Obstacle Manager
- [ ] Create empty GameObject named "ObstacleManager"
- [ ] Attach ObstacleSpawner.cs script

### PowerUp Manager
- [ ] Create empty GameObject named "PowerUpManager"
- [ ] Attach PowerUpSpawner.cs script

## ✅ UI Setup

- [ ] Create Canvas (Screen Space - Overlay)
- [ ] Add TextMeshPro for Score (top-left)
- [ ] Add Image for Boost Gauge (top-right)
- [ ] Add Button for Pause (top-center)
- [ ] Create Game Over Panel (initially disabled)
  - [ ] Add final score display
  - [ ] Add retry button

## ✅ Prefab Creation

Create prefabs for:
- [ ] Ramp obstacle
- [ ] MudPit obstacle  
- [ ] OilSlick obstacle
- [ ] NitroCan power-up
- [ ] ShieldStar power-up
- [ ] DoubleJump power-up

Each obstacle prefab needs:
- [ ] SpriteRenderer
- [ ] BoxCollider2D
- [ ] Appropriate tag
- [ ] MoveLeft.cs script
- [ ] DestroyOnLeftExit.cs script

Each power-up prefab needs:
- [ ] SpriteRenderer
- [ ] CircleCollider2D (isTrigger = true)
- [ ] Appropriate tag
- [ ] MoveLeft.cs script
- [ ] DestroyOnLeftExit.cs script

## ✅ Script Assignment

### GameManager
- [ ] Assign UI references (score text, boost gauge, buttons, panels)

### ObstacleSpawner  
- [ ] Assign obstacle prefab references

### PowerUpSpawner
- [ ] Assign power-up prefab references

### PlayerController
- [ ] Assign audio clip references

## ✅ Testing

- [ ] Test in Unity Editor with spacebar for jump
- [ ] Test in Unity Editor with left shift for boost
- [ ] Verify obstacles spawn and move left
- [ ] Verify power-ups spawn and can be collected
- [ ] Verify scoring system works
- [ ] Test game over functionality

## ✅ Android Build

- [ ] Build Settings → Android selected
- [ ] Player Settings configured correctly
- [ ] Create APK or test on device
- [ ] Verify touch controls work
- [ ] Test performance on target devices

## ✅ Final Polish

- [ ] Adjust physics values (jump force, boost force, gravity)
- [ ] Fine-tune spawn rates and positions
- [ ] Test game balance and difficulty
- [ ] Add background parallax elements if desired
- [ ] Test extensively on Android devices

---

## Common Issues & Solutions

**Scripts won't compile:**
- Check that all using statements are present
- Verify script names match file names exactly
- Make sure all required Unity packages are installed

**Physics feels wrong:**
- Adjust Gravity Scale on Player Rigidbody2D
- Tweak jumpForce and boostForce in PlayerController
- Ensure Fixed Timestep is set appropriately (Edit → Project Settings → Time)

**Sprites look blurry:**
- Set Filter Mode to "Point (no filter)" on all sprites
- Set Pixels Per Unit to 16
- Ensure camera size is appropriate for pixel art

**Touch input not working:**
- Verify Input.GetMouseButtonDown(0) is being used
- Test on actual device, not just editor
- Check that UI elements aren't blocking touches

**Game Over not triggering:**
- Ensure GameManager.Instance is set up correctly
- Verify collision detection is working
- Check that appropriate tags are set on GameObjects

Remember: Start simple, test often, and iterate on the gameplay feel! 