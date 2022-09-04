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
                        ShowDossier(ref dossier, ref position);
                        break;
                    case "3":
                        DellDossier(ref dossier, ref position);
                        break;
                    case "4":
                        FindDossier(ref dossier, ref position);
                        break;
                    case "5":
                        isWork = !isWork;
                        break;
                }
            }

            Console.WriteLine("Выход из программы");
        }

        static void AddDossier(ref string[] dossier, ref string[] position)
        {
            string[] tempDossier = new string[dossier.Length + 1];
            string[] tempPosition = new string[position.Length + 1];

            for (int i = 0; i < dossier.Length; i++)
            {
                tempDossier[i] = dossier[i];
                tempPosition[i] = position[i];
            }

            dossier = tempDossier;
            position = tempPosition;
            Console.WriteLine("Заполните ФИО сотрудника:");
            dossier[dossier.Length - 1] = Console.ReadLine();
            Console.WriteLine("На какой должности сотрудник работает?");
            position[position.Length - 1] = Console.ReadLine();
            Console.WriteLine();
        }

        static void ShowDossier(ref string[] dossier, ref string[] position)
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

        static void DellDossier(ref string[] dossier, ref string[] position)
        {
            Console.WriteLine("Досье под каким номером нужно удалить?");
            int indexForDeleating = Convert.ToInt32(Console.ReadLine());
            string[] tempDossier = new string[dossier.Length + 1];
            string[] tempPosition = new string[position.Length + 1];

            for (int i = 0; i < indexForDeleating - 1; i++)
            {
                tempDossier[i] = dossier[i];
                tempPosition[i] = position[i];
            }

            for (int i = indexForDeleating; i < dossier.Length; i++)
            {
                tempDossier[i - 1] = dossier[i];
                tempPosition[i - 1] = position[i];
            }

            dossier = tempDossier;
            position = tempPosition;
        }

        static void FindDossier(ref string[] dossier, ref string[] position)
        {
            Console.WriteLine("Введите фамилию для поиска:");
            string userInput = Console.ReadLine();

            for (int i = 0; i < dossier.Length; i++)
            {
                string fullName = dossier[i];

                foreach (var surnameFind in fullName.Split(' '))
                {
                    if (userInput == surnameFind)
                    {
                        Console.WriteLine(dossier[i] + " " + position[i]);
                    }
                }
            }
        }
    }
}

