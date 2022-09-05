using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHealt = 4;
            int maxHealth = 10;
            Console.CursorVisible = false;
            DrawBar(playerHealt,maxHealth,15);
        }

        static void DrawBar(int value, int maxValue, int position, char symbolHealth = '#', char symbolEmptyHealte = '_')
        {
            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbolHealth;
            }

            Console.SetCursorPosition(0, position);
            Console.Write("[");
            Console.Write(bar);
            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += symbolEmptyHealte;
            }

            Console.Write(bar);
            Console.Write("]");
            Console.ReadKey();
        }
    }
}