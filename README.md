# Flappy-Duck
Game developed in the unity engine, based on the original flappy bird game with a few twists

The game consists of a duck maneuvering through pipes and when it gets through each pipe, the score increases. I created the sky, the stars, the ground, and the pipes in gimp and imported them as assets in unity. I then added a parallaxer script to the clouds, the stars, and the pipes so that they would be moving towards the duck. This gives an effect that the duck is moving forward and towards the pipes with the clouds and stars moving slowing in the background but in reality the duck is not moving at all in the x axis. The sky and ground are not moving. 


There is only one scene but with three pages: the start page, the countdown page and the game over page. In the start page, the highscore is shown at the bottom of the screen and gets updated if the score acheived is ever greater than the saved highscore. The current score is at the top and is initially 0 and increments by 1 every time the duck successfully makes it through a pipe. To start the game, you tap the play button right underneath the highscore text and then a count down text shows up, counting down from 3 (this is the countdown page). The game ends when the duck hits either any of the pipes or the ground, this results in the gameover page which displays the text "Game Over" with a replay button underneath it. When the replay button is tapped, it takes you back to the start page. 


### Version Changes

###### Version 1
-Initial roll out of game, stable build. 

###### Version 1.1
-Changed speed of pipe movement, now move towards the duck faster. You can see this change in the "Pipes" game object under the parallaxer script.

-Added framerate change for iOS version to make movement smoother. Did this by creating Scenemanager script attached to empty game object scenemanager and setting framerate to 60 and disabling vSync. 
NOTE: Disable this script for all builds other than iOS.

###### Version 1.2
-Changed the gravity force, mass of duck, as well as tap force to create a more balanced and fluid game. Duck movement now feels much better.

NOTE: the iOS build folder does not contain the actual build files, I had to remove them since they were too large. (This goes for all versions)
You can create the build by going to: File -> Build Settings -> Build (Make sure iOS is selected)
Also make sure that the Scene Controller script is enabled before you do this. 


### To Do
-Add sound sound effects (when tapping on the screen to move duck, when duck scores a point, and when duck dies)

-Add more UI elements

-Can also try for a samsung TV build
