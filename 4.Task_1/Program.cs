using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string[] dossier = new string[0];
            string[] position = new string[0];

            while (isWork)
            {
                Console.WriteLine("Введите номер команды");
                Console.WriteLine("1 - Добавить досье");
                Console.WriteLine("2 - Показать все досье");
                Console.WriteLine("3 - Удалить выбранное досье");
                Console.WriteLine("4 - Поиск досье по фамилии");
                Console.WriteLine("5 - Выход из программы");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddDossier(ref dossier, ref position);
                        break;
                    case "2":
                        ShowDossier(dossier, position);
                        break;
                    case "3":
                        DeleteDossier(ref dossier, ref position);
                        break;
                    case "4":
                        FindDossier(dossier, position);
                        break;
                    case "5":
                        isWork = !isWork;
                        break;
                }
            }
            Console.WriteLine("Выход из программы");
        }

        static string[] ExpansionArray(ref string[] array)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
            return array;
        }

        static string[] CompressionArray (ref string[] array, int indexForCompressed)
        {
            string[] tempArray = new string[array.Length -1];

            for (int i=0; i< indexForCompressed-1; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i=indexForCompressed; i<array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }

            array = tempArray;
            return array;
        }

        static void AddDossier(ref string[] dossier, ref string[] position)
        {
            Console.WriteLine("Заполните ФИО сотрудника:");
            ExpansionArray(ref dossier);
            dossier[dossier.Length - 1] = Console.ReadLine();
            Console.WriteLine("На какой должности сотрудник работает?");
            ExpansionArray(ref position);
            position[position.Length - 1] = Console.ReadLine();
            Console.WriteLine();
        }

        static void ShowDossier(string[] dossier, string[] position)
        {
            Console.WriteLine();
            Console.WriteLine("Список всех досье:");

            for (int i = 0; i < dossier.Length; i++)
            {
                if (dossier[i] != "" && position[i] != "")
                {
                    Console.WriteLine((i + 1) + ". " + dossier[i] + " - " + position[i]);
                }
            }

            Console.WriteLine();
        }

        static void DeleteDossier(ref string[] dossier, ref string[] position)
        {
            Console.WriteLine("Досье под каким номером нужно удалить?");
            int indexForDeleating = Convert.ToInt32(Console.ReadLine());
            CompressionArray(ref dossier, indexForDeleating);
            CompressionArray(ref position, indexForDeleating);
        }

        static void FindDossier(string[] dossier, string[] position)
        {
            Console.WriteLine("Введите фамилию для поиска:");
            string userInput = Console.ReadLine();

            for (int i = 0; i < dossier.Length; i++)
            {
                string fullName = dossier[i];
                string[] surnameFind = fullName.Split(' ');

                if (userInput == surnameFind[0])
                {
                    Console.WriteLine(dossier[i] + " " + position[i]);
                }
            }
        }
    }
}
