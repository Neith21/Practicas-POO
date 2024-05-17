using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaTrece
{
    class Game
    {
        private int width = 40;
        private int height = 20;
        private List<(int x, int y)> snake = new List<(int x, int y)>();
        private (int x, int y) food;
        private Direction currentDirecction = Direction.Right;
        private bool gameRunning;
        private static readonly Random random = new Random();

        private enum Direction
        {
            Left, Right , Top, Bottom
        }

        public Game()
        {
            snake.Add((width / 2, height / 2));
            GenerateFood();
            gameRunning = true;
        }

        public void Start()
        {
            while (gameRunning)
            {
                AnsiConsole.Clear();
                DrawBorder();
                DrawSnake();
                DrawFood();
                HandleInput();
                Update();
                Thread.Sleep(100);
            }
        }

        private void DrawBorder()
        {
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#");
                Console.SetCursorPosition(x, height - 1);
                Console.Write("#");
            }
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");
                Console.SetCursorPosition(width - 1, y);
                Console.Write("#");
            }
        }

        private void DrawSnake()
        {
            foreach (var segment in snake)
            {
                Console.SetCursorPosition(segment.x, segment.y);
                Console.Write("0");
            }
        }

        private void DrawFood()
        {
            Console.SetCursorPosition(food.x, food.y);
            Console.Write("X");
        }

        private void GenerateFood()
        {
            food = (random.Next(1, width - 2), random.Next(1, height - 2));
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true).Key;
                var key = keyInfo.ToString().ToUpper();

                switch (key)
                {
                    case "W":
                        if (currentDirecction != Direction.Bottom)
                            currentDirecction = Direction.Top;
                        break;
                    case "S":
                        if (currentDirecction != Direction.Top)
                            currentDirecction = Direction.Bottom;
                        break;
                    case "A":
                        if (currentDirecction != Direction.Right)
                            currentDirecction = Direction.Left;
                        break;
                    case "D":
                        
                        if (currentDirecction != Direction.Left)
                            currentDirecction = Direction.Right;
                        break;
                }
            }
            
        }

        private void Update()
        {
            var head = snake[0];

            (int x, int y) newHead = head;

            switch (currentDirecction)
            {
                case Direction.Top:
                    newHead.y--;
                    break;
                case Direction.Bottom:
                    newHead.y++;
                    break;
                case Direction.Left:
                    newHead.x--;
                    break;
                case Direction.Right:
                    newHead.x++;
                    break;
            }

            if (newHead.x == 0 || newHead.x == width - 1 || newHead.y == 0 || newHead.y == height - 1 || snake.Contains(newHead))
            {
                gameRunning = false;
                Console.Clear();
                AnsiConsole.Write(new Markup("[bold red]Game Over![/]"));
                Thread.Sleep(2000);
                return;
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }
    }
}
