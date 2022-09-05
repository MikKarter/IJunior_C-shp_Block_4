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
            int resault;
            ParsingString(out resault);
            Console.WriteLine(resault);            
        }

        static int ParsingString(out int resault)
        {
            bool isWork = true;
            resault = 0;

            while (isWork)
            {
                string userInput = Console.ReadLine();
                int.TryParse(userInput, out int resaultParse);                

                if (resaultParse != 0)
                {                    
                    resault = resaultParse;
                    isWork = false;
                }

                else
                {
                    Console.WriteLine("Input error. Please, input any number:");
                }                
            }

            return resault;
        }
    }
}
