# Personal Portfio 4: Unit Testing

In this repositiory you will find the project files for my research in unit test and automating them using github actions.
The main branch only holds the readme file the since there are three projects hosted in this repository: [Getting Started](https://github.com/mathias-bevers/term2.4-personal-portfolio/tree/getting-started), [Minesweeper](https://github.com/mathias-bevers/term2.4-personal-portfolio/tree/minesweeper), and [Advent Of Code Framework](https://github.com/mathias-bevers/term2.4-personal-portfolio/tree/aoc).

## Advent Of Code Framework
This branch holds a framework I wrote for Advent Of Code. 
The framework currently runs in the console, but through different project in the same solution it can run in virtually every application.
Additionaly the solution also has a xUnit project which tests the puzzles with their sample input.
The xUnit test is autmated with a github [action](https://github.com/mathias-bevers/term2.4-personal-portfolio/blob/aoc/.github/workflows/dotnet.yml) ![aoc_workflow](https://github.com/mathias-bevers/term2.4-personal-portfolio/actions/workflows/dotnet.yml/badge.svg?branch=aoc)