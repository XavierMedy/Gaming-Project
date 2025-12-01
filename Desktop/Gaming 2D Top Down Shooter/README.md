Unity 6000.0.63f1 - 2D Top-Down Shooter (Keyboard + Mouse)
---------------------------------------------------------

This package targets Unity 6000.0.63f1 and configures the New Input System for:
- WASD: Move (2D vector composite)
- Left mouse button: Fire

Setup steps (on your Mac with Unity 6000.0.63f1):
1. Add the project folder in Unity Hub and open with Editor 6000.0.63f1.
2. Install the "Input System" package if prompted (Window -> Package Manager).
3. Open Assets/Input/PlayerControls.inputactions in the Input Actions editor.
4. Create a Player GameObject:
   - GameObject -> 2D Object -> Sprite. Assign Assets/Sprites/officer_shoot.png.
   - Tag as "Player". Add Rigidbody2D (Gravity=0). Add CircleCollider2D.
   - Add PlayerMovement and PlayerShoot components.
   - Create a child empty GameObject named "GunOffset" positioned at the muzzle. Assign it to PlayerShoot._gunOffset.
   - Create a Bullet prefab (SpriteRenderer, Rigidbody2D gravity=0, CircleCollider2D isTrigger=true, add Bullet.cs) and assign it to PlayerShoot._bulletPrefab.
5. Add a PlayerInput component to the Player and set:
   - Actions: Assets/Input/PlayerControls (drag)
   - Behavior: Send Messages
   - Default Map: Player
6. Play: WASD moves player, player rotates toward movement direction, left-click shoots bullets using transform.up.

Notes:
- I cannot run Unity here; you will need to perform the prefab & PlayerInput wiring in the Editor.
- The project avoids old InputManager files to prevent Safe Mode issues.
