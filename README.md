# Forms Be Relative
Forms Be Relative is a puzzle platformer, where the goal is to collect the shapes into their matching boxes.
Your influence the outcome via the player and a sort of button, which allows you to transform squares into circles and vice versa.

I've managed to create five levels, but more would be needed in order for the game to be complete. Adding new levels is easy and I look forward to adding different mechanics.

I quite like games such as Braid and The Witness, where no instructions are given, which I've mimicked in here.

An executable for MacOS is in the `Executables` folder.

## Controls
Move Right  : D / ->

Move Left   : A / <-

Jump        : Space

Continue    : Enter / Return

Access Menu : Escape

## Inventory System
While I don't have an inventory system, I do save the current level in PlayerPrefs and it is possible to continue playing where you left off after a game restart. To do so, simply press the `Continue` button from the main menu. Based on QA in class, I believe this should qualify as the mentioned extra credit inventory system.

## Graphics / Audio
I created all the music and sound effects myself.
The game-style lends itself to basic graphics, so the sprites I created were very simple in nature. I also created the splash screen, all of it using Krita.

## Acknowledgement
- My `Singleton` implementation was heavily inspired by [this Wiki.Unity3d.com example.](http://wiki.unity3d.com/index.php?title=Singleton&oldid=20231)
- The `CharacterController` was inspired by [this generic 2D Character Controller by Brackeys.](https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs)


