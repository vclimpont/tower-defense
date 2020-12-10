# Tower Defense prototype

This project is a quick prototype of a tower defense like game made with Unity.

The player must protect his base from enemies waves by spawning and upgrading turrets on the field.

## Turrets behaviour

Turrets can be spawned and rotated on a grid generated on the field.

3 types of turrets are prototyped : 
* **Cannons** : they fire at the closest enemy in their detection area.
* **Flamethrowers** : They fire at every enemies in their detection area.
* **Ionic turrets** : they slow every enemies in their detection area.

## Turrets upgrade

The player is able to upgrade spawned turrets using resources dropped on enemis' death.

Upgrades : 
**Cannons** : They can hit more than one enemy at the same time and their detection area is increased.
**Flamethrowers** : A second flamethrower is added behind the turret.
**Ionic turret** : they can also freeze enemies in their detection area for a short amount of time.

## Enemies behaviour

Every enemies follow a preset path from their spawn location to the player's base. 
3 types of enemies are prototyped with different speed, health and damages caused.
