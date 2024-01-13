using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Maze.Scripts.Maze.Spawner
{
    public class MazeSpawner
    {
        private readonly float _cellSize;

        private readonly Cell _cellPrefab;
        private readonly GameObject _finishPrefab;
        private readonly GameObject _startPrefab;
        private readonly Transform _cellsParent;

        private readonly MazeGenerator _generator;

        public MazeGenerator Generator => _generator;

        public MazeSpawner(int minWidth, int minHeight, int maxWidth, int maxHeight, float cellSize, Cell cellPrefab)
        {
            _cellSize = cellSize;
            _cellPrefab = cellPrefab;
            
            var width = Random.Range(minWidth, maxWidth);
            var height = Random.Range(minHeight, maxHeight);
            
            _generator = new MazeGenerator(width, height);
        }
        
        public void SpawnMaze()
        {
            for (int i = 0; i < _generator.Maze.GetLength(0); i++)
            {
                for (int j = 0; j < _generator.Maze.GetLength(1); j++)
                {
                    var cell = Object.Instantiate(_cellPrefab, new Vector3(i, 0f, j) * _cellSize, Quaternion.identity, _cellsParent);
                    
                    cell.wallLeft.SetActive(_generator.Maze[i,j].wallLeft);
                    cell.wallBottom.SetActive(_generator.Maze[i,j].wallBottom);
                    cell.floor.SetActive(_generator.Maze[i,j].floor);
                }
            }

            #region Finish

            /*Object.Instantiate(_finishPrefab,
    new Vector3(_generator.FinishCell.x, 0f, _generator.FinishCell.y) * _cellSize,
    Quaternion.identity);*/

            #endregion

        }
    }
}
