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
            int resault;

            while (isWork)
            {                
                ParsingString(out resault);

                if (resault == 0)
                {
                    Console.WriteLine("Input error. Please, input any number:");
                }
                else
                {
                    Console.WriteLine(resault);
                    isWork = false;
                }
            }
        }

        static int ParsingString(out int resault)
        {
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int resultParse);
            resault = resultParse;
            return resault;
        }
    }
}
