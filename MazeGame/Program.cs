namespace MazeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(40, 20);

            while (true)
            {
                maze.DrawMaze();
                maze.MovePlayer();
            }
          

        }
    }
}
