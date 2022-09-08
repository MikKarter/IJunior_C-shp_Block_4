using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4.Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool isPlaying = true;
            int playerPositionX;
            int playerPositionY;
            int playerDirectionX = 0;
            int playerDirectionY = 0;
            char[,] map = ReadMap("Map1", out playerPositionX, out playerPositionY);
            DrawMap(map);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangePosition(ref key,ref playerDirectionX,ref playerDirectionY);
                    
                    if (map[playerPositionX + playerDirectionX, playerPositionY + playerDirectionY] != '*')
                    {
                        MovePlayer(ref playerPositionX, ref playerPositionY, playerDirectionX, playerDirectionY);
                    }
                }                
            }
        }

        static void ChangePosition (ref ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1; 
                    directionY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    directionY = 1;
                    directionX = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionY = -1;
                    directionX = 0;
                    break;
            }

        }

        static void MovePlayer(ref int positionX, ref int positionY, int directionX, int directionY)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(' ');
            positionX += directionX;
            positionY += directionY;
            Console.SetCursorPosition(positionY, positionX);
            Console.Write('#');
        }

        static char[,] ReadMap(string mapName, out int playerPositionX, out int playerPositionY)
        {
            playerPositionX = 0;
            playerPositionY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '#')
                    {
                        playerPositionX = i;
                        playerPositionY = j;
                    }
                }
            }
            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
