This is my current project i have been working on. ﻿ShootingDot is a 2D top-down shooter game. The map is generated differently every run. The main goal of the game is to eliminate all enemies and spawners. I want to add a few game modes and a multiplayer in the future.

MapCreationScript is a script that creates the whole map and it spawns on random positions the Weapon spawners, the Enemy spawners and the player.

BulletScript is used by the player and the enemies.

ButtonImage is used in the Main Menu to adjust the button to have circular hit box.

CharacterController is used for the movement of the player (It's not requaired to have a complicated movement for this game).

EnemyShooting is used for every weapon on the enemy.

EnemyWeapon is used to rotate the weapon around the enemy and to change its weapons.

Weapon Script is used to rotate the weapon around the player and to change its weapons.

GameOverScreen is spawned (it is literally spawned) when the player dies.

ShootingScript is used for every weapon on the player.

SpawnWeapon is used on the weapon spawners that are randomly generated on the map.

SpawnerScript is used by the Enemy Spawner, Enemy Spawners are generated randomly on the map.

TracingBullet is used by the Tracing Gun. The bullet locks on the closest target and it goes directly towards the enemy.

TracingBulletEnemy is used by the Tracing Gun it does the same thing, but the new target is the player.

TriggerChangePos is used by a GameObject with a trigger. This GameObject works with the Unity Pathfinding to navigate the enemy.



