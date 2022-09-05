using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            bool isWork = true;

            while (isWork)
            {
                string userInput = Console.ReadLine();
                StringParce(userInput,ref isWork);
            }
        }

        static void StringParce (string inputText, ref bool value)
        {
            int.TryParse(inputText, out int resultParse);
            if (resultParse == 0)
            {
                Console.WriteLine("Input error. Please, input any number:");
            }
            else
            {
                Console.WriteLine(resultParse);
                value = false;
            }
        }
    }
}
