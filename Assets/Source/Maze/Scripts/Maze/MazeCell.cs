namespace Source.Maze.Scripts.Maze
{
    public class MazeCell
    {
        public int x;
        public int y;

        public bool wallLeft = true;
        public bool wallBottom = true;
        public bool floor = true;

        public bool isVisited = false;
        public int distanceFromStart;
    }
}