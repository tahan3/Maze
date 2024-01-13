using UnityEngine;

namespace Source.Maze.Scripts.Maze.Config
{
    [CreateAssetMenu(fileName = "MazeConfig", menuName = "Maze Spawn Configuration", order = 0)]
    public class MazeSpawnConfig : ScriptableObject
    {
        public int maxWidth;
        public int maxHeight;
        public float cellSize;
        public int minWidth;
        public int minHeight;
    }
}