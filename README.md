# CallOfCandy

## game play

you're a teenager in a house where candy is gonna try to kill you, each candy has a colour (red, green, blue, cyan, magenta, white), the teenager has a weapon with a colour.


Candies can only be touched by the same colour or a colour that contains that same colour. The blue, red and green candies have a close attack. Cyan, magenta and white candy can shoot from a distance. Candies by touching the player have a probability of removing a secondary color.


By dying candies gives a number that is added to the score displayed on the HUD, each candy has a probability of leaving a bonus item.

There are four types of bonuses:

* BonusHeal - BonusHeal - restores the player's entire life.
* BonusLife - increases the maximum lifespan by one, and restores one life point.
* BonuesMerge - the colour of the gun mixes with another colour to make it a secondary colour (red -> yellow, green-> cyan, blue-> magenta).
* BonusWhite - makes the player invisible for 15 seconds


## Contenu 
### Assets
#### GamerSquid
contains all the elements for the lamps in the main house.
#### model3d2d
contains the different assets for the candys, the house, the weapons, the images for the different scenes.
#### Particlecollection_free samples
contains the prefabs that make up part of the Bonuses.
#### Prefab
* ball - prefab of the player's balls
* Color - the possible colors in the game
* Enemies - all elements compensate for enemies
'* animation - the animations of all candies' 
'* ball - prefabs of different projectiles of candy'. 
'* Bonuses - various bonus prefabs'
'* Prefabs - prefabs of different candies and wave 1 1'
'* sounds - the different sounds of enemies'

#### Scenes
contains the different scenarios of the game
* Commands - image of the different commands
* Level - scene with the house and HUD
* Mainscreen - main menu scene

#### Scripts
* enemy - contains the different scripts for enemies.
* Player - contains different scripts for the player and bonuses.


### Levels 
#### Commands
* function 
displays the different game controls
* content 

#### Level
* function 
contains the levels of the game
* content 

#### MainScreen
* function 
displays the main menu of the game
* content 
 