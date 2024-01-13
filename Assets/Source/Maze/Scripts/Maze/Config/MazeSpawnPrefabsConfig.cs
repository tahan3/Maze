using UnityEngine;

namespace Source.Maze.Scripts.Maze.Config
{
    [CreateAssetMenu(fileName = "MazePrefabs", menuName = "Maze Spawn Prefabs", order = 0)]
    public class MazeSpawnPrefabsConfig : ScriptableObject
    {
        public Cell cellPrefab;
        public GameObject startPrefab;
        public GameObject finishPrefab;
    }
}