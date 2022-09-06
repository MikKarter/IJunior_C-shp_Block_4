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
            int playerX;
            int playerY;
            int playerDX = 0;
            int playerDY = 0;
            char[,] map = ReadMap("Map1", out playerX, out playerY);
            Drawmap(map);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangePosition(ref key,ref playerDX,ref playerDY);
                    
                    if (map[playerX + playerDX, playerY + playerDY] != '*')
                    {
                        MovePlayer(ref playerX, ref playerY, playerDX, playerDY);
                    }
                }
                
            }
        }

        static void ChangePosition (ref ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    DY = 1; DX = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DY = -1; DX = 0;
                    break;
            }

        }

        static void MovePlayer(ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(' ');
            X += DX;
            Y += DY;
            Console.SetCursorPosition(Y, X);
            Console.Write('#');
        }

        static char[,] ReadMap(string mapName, out int playerX, out int playerY)
        {
            playerX = 0;
            playerY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];
                    if (map[i, j] == '#')
                    {
                        playerX = i;
                        playerY = j;
                    }
                }
            }
            return map;
        }

        static void Drawmap(char[,] map)
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

        //static void PlayerController()
        //{
        //    Console.KeyAvailable = ConsoleKey.UpArrow;
        //}
    }
}
