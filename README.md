# Simple Rock Shooting Game
This is simple game made as a pass task in the high school some years ago. The game is about schooting to rocks from your space ship. As I dont like 2d graphics all images used in game are really bad😢 (as you see in previev image). Made in c# language in Windows Forms framework. 
## How to play
The gameplay is really easy. After you download files, open exe file ad you can play. Unfortunatelly it is not possible to scale a game window. 
1. Firstly, you choose a difficulty level (it has affect on rock spawning speed and the rock acceleration in time parameter). 
2. You move the space shit holding left/right arrow ⬅️➡️
3. You shot using space
4. Avoid rock and collect extra armor from colored rock but only when you destroy them first
5. Try be alive as long as you can and then, play again

![Picture of gameplay](https://github.com/user-attachments/assets/73b0c5e7-bafa-4edc-a6aa-2ab517b7c0f4)

## How it work?
~~It is a good question in which I also want to know an answer.~~
- Windows Forms is not a good platform for games, but I choose it because of time which I had ~~or to be more precise I hadn`t~~. 
- Every object which participant in gameplay (rocks, bonuses, shots and spaceship) are inherited from main GameObject class. 
- The whole space is represented as a coordinate system. Due to this every game object has his own hitbox represented as rectangle. The spaceship is the only one which use multirectangular hitbox. 
- The rocks objects are created every second.
- In every frame of game the collision of spaceship with all rocks is checked
- When the rock fly away from the space is destroyed.
- For the game all objects exist only as hitboxes so apart from moving them on the screen, the game need to move every hitbox of every object based on his real movement. It happend in every frame.

## Download
![Files to download](release)
Unzip and play😃
