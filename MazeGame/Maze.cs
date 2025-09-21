using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Maze
    {
        private int _Width;
        private int _Height;
        private Player _Player;
        private IMazeObject[,] _MazeObjectsArray;
        public Maze(int width, int height)
        {
            _Width = width;
            _Height = height;
            _MazeObjectsArray= new IMazeObject[width, height];
            _Player = new Player()
            {
                X = 1,
                Y = 1
            };
        }
        public void DrawMaze()
        {
            Console.Clear();
            for (int Y = 0; Y < _Height; Y++)
            {
                for (int X = 0; X < _Width; X++)
                {
                    if (X==_Width-1&& Y==_Height-2)
                    {
                        _MazeObjectsArray[X, Y] = new EmptySpace();
                        Console.Write(_MazeObjectsArray[X, Y].Icon);
                    }
                    else if ( X == 0 || X==_Width-1 || Y==0 || Y == _Height-1)
                    {
                        _MazeObjectsArray[X, Y] = new Wall();
                        Console.Write(_MazeObjectsArray[X, Y].Icon);
                    }
                    else if (X== _Player.X && Y==_Player.Y)
                    {
                        Console.Write(_Player.Icon);
                    }
                    else if(X%3==0 && Y % 3 == 0)
                    {
                        _MazeObjectsArray[X, Y] = new Wall();
                        Console.Write(_MazeObjectsArray[X, Y].Icon);
                    }
                    else if (X % 5 == 0 && Y % 5 == 0)
                    {
                        _MazeObjectsArray[X, Y] = new Wall();
                        Console.Write(_MazeObjectsArray[X, Y].Icon);
                    }
                    else
                    {
                        _MazeObjectsArray[X,Y] = new EmptySpace();
                        Console.Write(_MazeObjectsArray[X, Y].Icon);
                    }
                   
                }
                Console.WriteLine();
            }
        }

        public void MovePlayer()
        {
            var UserInput = Console.ReadKey();
            var key = UserInput.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(0, -1);
                    break;


                case ConsoleKey.DownArrow:
                    UpdatePlayer(0, 1);
                    break;


                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1, 0);
                    break;


                case ConsoleKey.RightArrow:
                    UpdatePlayer(1,0);
                    break;
            }
        }

        private void UpdatePlayer(int dx, int dy)
        {
            int newX = _Player.X + dx;
            int newY = _Player.Y + dy;

            if(newX<_Width && newX>=0 && newY<_Height && newY >= 0 && _MazeObjectsArray[newX,newY].IsSolid==false) 
            {
                _Player.X = newX;
                _Player.Y = newY;
                DrawMaze();
            }
        }
    }
}
