# Personal Portfio 4: Unit Testing

In this repositiory you will find the project files for my research in unit test and automating them using github actions.
The main branch only holds the readme file the since there are three projects hosted in this repository: [Getting Started](https://github.com/mathias-bevers/term2.4-personal-portfolio/tree/getting-started), [Minesweeper](https://github.com/mathias-bevers/term2.4-personal-portfolio/tree/minesweeper), and [Advent Of Code Framework](https://github.com/mathias-bevers/term2.4-personal-portfolio/tree/aoc)

# Minesweeper
This branch contains the minesweeper game I made in Unity3D, [download](https://github.com/mathias-bevers/term2.4-personal-portfolio/releases) via the releases page. 
Currently, the game has only one difficulty and a basic game loop.  
Additionaly the game is (partially) tested using [Unity's Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html). 
These tests are also automated using an [action](https://github.com/mathias-bevers/term2.4-personal-portfolio/blob/minesweeper/.github/workflows/unity.yml), which are jobs from [GameCI](https://game.ci/).
<br>
![unity](https://github.com/mathias-bevers/term2.4-personal-portfolio/actions/workflows/unity.yml/badge.svg?branch=minesweeper)