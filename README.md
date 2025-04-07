# Table of Contents
- [Introduction](#introduction)
- [Position and Direction](#position-and-direction)
- [Pieces](#image-example)
- [Position and possible moves](#position-and-moves)
## Introduction
this project follow tutorial from https://www.youtube.com/@OttoBotCode


Logic:<br/>
&nbsp;&nbsp;GameState <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Player (who, who go first)<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Board <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pieces<br/>

## Position and Direction
record changes to the code
the table start from the top left to the bottom right 0 -> 7
and the position, direction, after overwrite operator, we can enable 
things like this in image:
* from : current position
* to : from + 3 square to the Direction.SouthEast
* this will simplified everything 


<img src="./mdsrc/scrs_direction_pos.png">


## Pieces
all pieces derived from the base class Piece
in /Chest.Logic/Pieces/abstract

## position-and-moves
- this is among the main logic, we first pick a piece <br/>
- then we get its possible moves ( N, S , NE, NW ,...) <br/>
- then in that direction we check how far it can go till it reach the board 
or it meet another pieces ( if of opponent piece, then means it can 
be taken)<br/>
ex img:
<img src="./mdsrc/scrs_moves_position.png">
- when it reach something, stop, and color those possible path