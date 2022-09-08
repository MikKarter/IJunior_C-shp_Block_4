using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mainArray = CreatingNewArray();
            WriteArray(mainArray);
            Shuffle(ref mainArray);
            WriteArray(mainArray);
        }

        static int[] CreatingNewArray()
        {
            int lowerNumber = 0;
            int upperNumber = 20;
            Random tempNumber = new Random();
            int[] tempArray = new int[upperNumber];

            for (int i = 0; i < tempArray.GetLength(0); i++)
            {
                tempArray[i] = tempNumber.Next(lowerNumber, upperNumber);
            }

            return tempArray;
        }

        static void Shuffle(ref int[] mainArray)
        {
            Random tempNumber = new Random();           
            
            for (int i = 0; i < mainArray.Length; i++)
            {
                int tempRandomi = tempNumber.Next(0, mainArray.Length);
                int tempValue;
                tempValue = mainArray[i];
                mainArray[i]=mainArray[tempRandomi];
                mainArray[tempRandomi] = tempValue;
            }
        }

        static void WriteArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            
            Console.WriteLine();
        }
    }
}
