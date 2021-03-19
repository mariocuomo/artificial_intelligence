# Artificial Intelligence
<p align="center"><img alt="Artificial_Intelligence" src="https://github.com/mariocuomo/artificial_intelligence/blob/main/AI_chess.jpg" /></p>

This Repository is dedicated to different test and Artificial Intelligence algorithms inspired by the Artificial Intelligence course at Roma Tre University.
<br>The project is an App Console(.NET Core) developed using C#.

## Search Path With Cost 
I'm in <b>Milan - MI -</b> and I want to go to <b>Naples - NA</b>.<br>
I have a map of Italy that represents the operators and their costs associated: the map indicates which cities are directly connected, together the relative cost of travel.

. | AQ | AN | BA | BO | FI | GE | MI | NA | PG | PI | RM | TO
--- | --- | --- | --- |--- |--- |--- |--- |--- | -- |--- | --- |---
<b>AQ</b> |  | 19 |  | | | | | | 17  | | 11 |
<b>AN</b> | 19 |  | 46 | 21 | | | | | 16 | | |
<b>BA</b> |  | 46 |  | | | | | | | |45|
<b>BO</b> |  | 21 |  | |10 | |21 | | | | | 
<b>FI</b> |  |  |  |10 | |22 | | |15 |9 |28| 
<b>GE</b> |  |  |  | |22 |14 | | |16 | | | 
<b>MI</b> |  |  |  |21 | |14 | | | | | |14
<b>NA</b> |  |  |  | | | | | | | |22| 
<b>PG</b> | 17 | 16 |  | |15 | | | | | |17| 
<b>PI</b> |  |  |  | |9 |16 | | | | |37| 
<b>RM</b> | 11 |  | 45 | |28 | | |22 |17 |37 ||
<b>TO</b> |  |  |  | | | |14 | | | ||

. | DISTANCE AS CROW FLIES TO NA 
--- | --- 
<b>AQ</b> | 18
<b>AN</b> | 31
<b>BA</b> | 22
<b>BO</b> | 47
<b>FI</b> | 40
<b>GE</b> | 58
<b>MI</b> | 65
<b>PG</b> | 19
<b>PI</b> | 44
<b>RM</b> | 18
<b>TO</b> | 71


©Roma Tre - Artificial Intelligence course



## Uninformed Search Algorithms
These algorithms don't have any information about the problem and for this reason they are often the least efficient.<br>
Currently implemented:
- [x] Breadth First Search
- [x] Depth First Search
- [x] Limited Depth First Search
- [x] Iterative Limited Depth First Search
- [x] Uniform Cost Search

## Heuristic Search Algorithm
Heuristic search is a form of search that exploits knowledge about a problem to find solutions more efficiently.<br>
Currently implemented:
- [x] Greedy Search
- [x] A* search


## Tic Tac Toe Game
Using MinMax algorithm to suggest the best choice in the tic-tac-toe game at each step.<br>
The algorithm is for perfect decisions, i.e. all possible combinations are expanded
<p align="center"><img alt="Artificial_Intelligence" src="https://github.com/mariocuomo/artificial_intelligence/blob/main/Tic Tac Toe.PNG" /></p>


## Python Test
This folder is dedicated to different Python test.<br>
Currently it contains files not related to programming for Artificial Intelligence. 





