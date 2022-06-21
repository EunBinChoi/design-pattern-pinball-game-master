# Pinball Game
A pinball game is implemented with state pattern and singleton pattern applied.

## How to Play Pinball Game
Pinball is an arcade game in which a ball rolls and is propelled inside a specially designed cabinet known as a pinball machine, hitting various lights, bumpers, ramps, and other targets depending on its design. The game's object is generally to score as many points as possible by hitting these targets and making various shots with flippers before the ball is lost. Most pinball machines use one ball per turn (except during special multi-ball phases), and the game ends when the ball(s) from the last turn are lost.

## Which Patterns Applied
1) State Pattern: Object such as the spring or the door has characteristic that behavior changes depending on the state.
  * while playing the pinball game, the spring and door has 4 states respectively.
    - Spring: ready state, spring compression state, spring compression released state, spring return back state
    - Door: ready state, state where the ball passes by the door, state where the door starts to move, state where the
door is closed
  
2) Singleton Pattern: restriction on the instantiation of a class to one "single" instance. This is useful when exactly one object is needed to coordinate actions across the system.
  * while playing this pinball game, the only one ball presents.

