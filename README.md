# Table of Contents
- [Introduction](#introduction)
- [Position and Direction](#position-and-direction)
- [Pieces](#image-example)
- [Position and possible moves](#position-and-moves)
- [Select and move cache](#select-and-move-cache)
## Introduction
this project follow tutorial from https://www.youtube.com/@OttoBotCode


Logic:<br/>
&nbsp;&nbsp;GameState <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Player (who, who go first)<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Player[]<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Board <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurrentPiece <br/>
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


## select-and-move-cache
- this is the main logic of the game, when we select a piece, we need to
1. select a piece <br/>
2. get position and the move at that position <br/>
3. get all the moves of that piece at the position <br/>
4. set the cache ( with key being the possible ToPosition in move, value being the move itself ), 
get the move from the cache
then display on the grid 
<img src="./mdsrc/srcs_movecache_select_explain.png">>