using Source.Maze.Scripts.Maze.Config;
using Source.Maze.Scripts.Maze.Spawner;
using UnityEngine;

namespace Source.Maze.Scripts.Maze
{
    public class MazeBoot : MonoBehaviour
    {
        [SerializeField] private MazeSpawnConfig spawnConfig;
        [SerializeField] private MazeSpawnPrefabsConfig mazePrefabs;
        
        private void Start()
        {
            MazeSpawner mazeSpawner = new MazeSpawner(
                spawnConfig.minWidth,
                spawnConfig.minHeight,
                spawnConfig.maxWidth,
                spawnConfig.maxHeight,
                spawnConfig.cellSize,
                mazePrefabs.cellPrefab);

            mazeSpawner.SpawnMaze();

            var startCell = mazeSpawner.Generator.Maze[0, 0];
            var finishCell = mazeSpawner.Generator.FinishCell;

            Instantiate(mazePrefabs.startPrefab, new Vector3(startCell.x, 0f, startCell.y) * spawnConfig.cellSize, Quaternion.identity);
            Instantiate(mazePrefabs.finishPrefab, new Vector3(finishCell.x, 0f, finishCell.y) * spawnConfig.cellSize, Quaternion.identity);
        }
    }
}