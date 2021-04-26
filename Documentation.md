## Player movement behaviour
before we moved with wasd now movement is using the nav mesh
### variables
- (private: float) moveSpeed: 
how fast the player will move
- (private: Camera) camera: 
used for movement
- (private: NavMeshAgent) agent: 
used to place the player actaul movement
- (private: PlayerMeleeBehaviour) meleeBehaviour:
how the player will use his melee attack
## Camera Follow Behaviour 
instead of being still camera i allowed the camera to follow a spesified target
### variables
- (private: Gameobject) target: 
the target the camera will follow
- (private: Vector3) offset:
grabs the offset of the camera from the center of the scene
## Closest Target Behaviour 
a blackboard that ask for the closest target to player
### Variables
- (public: List of gameobjects) Targets: 
gets every target in scene
- (private PlayerShootBejvaiour) shootBehaviour: 
used to set the behaviour target variable
- (private: GameObject) player
used to get teh distance between each target and the player
## player melee behaviour 
a simple push to enemy and subtrace health from target
### variables
- (private: float)damage: 
how much damage the target will take
### functions
- Attack(Gameobject):
pushes the enemy and applies the damage to enemy
## player shoot behaviour 
it use to shoot a bullet when a mouse button is pressed now auto matically shoots when teh closest target is near
### variables
- (private: BulletEmitterBehaviour)bulletEmitter: 
where the bullet is fireing from
- (private: float)range: 
how close the target need to be for the plaer to shoot
- (private: float)timePerShoot: 
how fast the player can shoot
- (public: Gameobject) target: 
the target the player is shooting at
- (private: float) time
and incrementint time dosn't need to be touched
## spawner Behaviour 
### variables
- (private: GameObject)spawnObject: 
the prefab that the spawner will spawn
- (private: float)timeBetweenSpawns: 
how long for an enemy to spawn
- (private: bool)canSpawn: 
the variable that allows the spawner to spawn objects
- (private: GameObject)enemyTarget: 
set the enemy target
- (private: ClosestTargetBehaviour)targetBehaviour: 
add each enemy spawned to the balck board
### functions
- spawnObjects(void): 
this is a coroutine that spawns the object
## Game Manager Behaviour
### variables
- (private Static: bool) gameOver
opens the gameover screen when player is dead
- (private: HealthBehaviour) playerHealth
the behaviour that gets the player health
- (private: GameObject) gameOverScreen
the object reponsible for the game over screen
- (private: GameObject) rangedButton
the object reponsible for the ranged button
- (private: GAmeObject) meleeButton
the object reponsible for the melee button
### functions
- public void: RestartGame(void): 
reloads the scene
- public void: QuitGame(void): 
closes the application window
- public void: MeleeMode(void):
switches the buttons for melee to range
- public void: RangedMode(void): 
switches the buttons for range to melee
## Health Bar Behaviour
### Variables
- (private: HealthBehaviour) health
the health of the target
- (private: Gradiant) healthGradiant
can be change to change how the health bar will look
- (private: Image) fill
changes the color of the fill image
- (private: Slider) slider
gets information from the slider on the object attached
## Face Camera Behaviour
### Variables
- (private: Camera) camera
transforms objects to the camera rotation
## Enemy Movement Behaviour
### variables
- (private: GameObject) target
set the objects destination based on target location
- (private: NavMeshAgent) agent
what dictates how the object will move
## Health Behaviour
### variables
- (private: float) health: 
stores teh amount of health the object has
- (private: bool) destroyOnDeath: 
gives the option to destroy teh object when its health drops to 0
### functions
- (public void) TakeDamage(float): 
subtracts damage to the object called health
## bullet Emitter Behaviour
### variables
- (private: GameObject) bullet
stores the object that will be fired
### functions
- (private: void) Fire(vector3): 
fires a bullet at a given direction
## Bullet Behaviour
### variables
- (private: Rigidbody) rigidbody
stores the rigidbody of the object
- (private: float) damage
how much damage this bullet will do
- (private: float) despawnTime
the amount of time it takes for this bullet to despawn
## Enemy Attack Behaviour
### variables
- (private: float) damage
how much damage this bullet will do to the target it touches
- (private: EnemyMovementBehaviour) movement
grabs the movements target  and check if the collision has that target