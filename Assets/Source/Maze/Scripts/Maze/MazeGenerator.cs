using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Source.Maze.Scripts.Maze
{
    public class MazeGenerator
    {
        private readonly int _width;
        private readonly int _height;

        private readonly MazeCell[,] _maze;
        private MazeCell _finishCell;

        public MazeCell[,] Maze => _maze;
        public MazeCell FinishCell => _finishCell;

        public MazeGenerator(int width, int height)
        {
            _height = height;
            _width = width;
            _finishCell = new MazeCell();
            _maze = GenerateMaze();
        }

        private MazeCell[,] GenerateMaze()
        {
            var maze = new MazeCell[_width, _height];
            
            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    maze[i, j] = new MazeCell() { x = i, y = j };
                }
            }

            for (int i = 0; i < _width; i++)
            {
                maze[i, _height - 1].wallLeft = false;
                maze[i, _height - 1].floor = false;
            }
            
            for (int i = 0; i < _height; i++)
            {
                maze[_width - 1, i].wallBottom = false;
                maze[_width - 1, i].floor = false;
            }
            
            RemoveWallsWithBacktracker(maze);
            
            return maze;
        }

        private void RemoveWallsWithBacktracker(MazeCell[,] maze)
        {
            MazeCell current = maze[0, 0];
            current.isVisited = true;
            current.distanceFromStart = 0;

            Stack<MazeCell> stack = new Stack<MazeCell>();

            do
            {
                List<MazeCell> unvisitedCells = new List<MazeCell>();

                int x = current.x;
                int y = current.y;

                if (x > 0 && !maze[x - 1, y].isVisited) unvisitedCells.Add(maze[x - 1, y]);
                if (y > 0 && !maze[x, y - 1].isVisited) unvisitedCells.Add(maze[x, y - 1]);
                if (x < _width - 2 && !maze[x + 1, y].isVisited) unvisitedCells.Add(maze[x + 1, y]);
                if (y < _height - 2 && !maze[x, y + 1].isVisited) unvisitedCells.Add(maze[x, y + 1]);

                if (unvisitedCells.Count > 0)
                {
                    MazeCell chosen = unvisitedCells[Random.Range(0, unvisitedCells.Count)];
                    RemoveWall(current, chosen);
                    chosen.isVisited = true;
                    stack.Push(chosen);
                    current = chosen;
                    chosen.distanceFromStart = stack.Count;

                    if (_finishCell.distanceFromStart < chosen.distanceFromStart)
                    {
                        _finishCell = chosen;
                    }
                }
                else
                {
                    current = stack.Pop();
                }

            } while (stack.Count > 0);
        }

        private void RemoveWall(MazeCell current, MazeCell chosen)
        {
            if (current.x == chosen.x)
            {
                if (current.y > chosen.y)
                {
                    current.wallBottom = false;
                }
                else
                {
                    chosen.wallBottom = false;
                }
            }
            else
            {
                if (current.x > chosen.x)
                {
                    current.wallLeft = false;
                }
                else
                {
                    chosen.wallLeft = false;
                }
            }
        }
    }
}