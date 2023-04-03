using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Homework_06
{
    class Program
    { 
        /// Домашнее задание
        ///
        /// Группа начинающих программистов решила поучаствовать в хакатоне с целью демонстрации
        /// своих навыков. 
        /// 
        /// Немного подумав они вспомнили, что не так давно на занятиях по математике
        /// они проходили тему "свойства делимости целых чисел". На этом занятии преподаватель показывал
        /// пример с использованием фактов делимости. 
        /// Пример заключался в следующем: 
        /// Написав на доске все числа от 1 до N, N = 50, преподаватель разделил числа на несколько групп
        /// так, что если одно число делится на другое, то эти числа попадают в разные группы. 
        /// В результате этого разбиения получилось M групп, для N = 50, M = 6
        /// 
        /// N = 50
        /// Группы получились такими: 
        /// 
        /// Группа 1: 1
        /// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
        /// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
        /// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
        /// Группа 5: 16 24 36 40
        /// Группа 6: 32 48
        /// 
        /// M = 6
        /// 
        /// ===========
        /// 
        /// N = 10
        /// Группы получились такими: 
        /// 
        /// Группа 1: 1
        /// Группа 2: 2 7 9
        /// Группа 3: 3 4 10
        /// Группа 4: 5 6 8
        /// 
        /// M = 4
        /// 
        /// Участники хакатона решили эту задачу, добавив в неё следующие возможности:
        /// 1. Программа считыват из файла (путь к которому можно указать) некоторое N, 
        ///    для которого нужно подсчитать количество групп
        ///    Программа работает с числами N не превосходящими 1 000 000 000
        ///   
        /// 2. В ней есть два режима работы:
        ///   2.1. Первый - в консоли показывается только количество групп, т е значение M
        ///   2.2. Второй - программа получает заполненные группы и записывает их в файл используя один из
        ///                 вариантов работы с файлами
        ///            
        /// 3. После выполения пунктов 2.1 или 2.2 в консоли отображается время, за которое был выдан результат 
        ///    в секундах и миллисекундах
        /// 
        /// 4. После выполнения пунта 2.2 программа предлагает заархивировать данные и если пользователь соглашается -
        /// делает это.
        /// 
        /// Попробуйте составить конкуренцию начинающим программистам и решить предложенную задачу
        /// (добавление новых возможностей не возбраняется)
        ///
        /// * При выполнении текущего задания, необходимо документировать код 
        ///   Как пометками, так и xml документацией
        ///   В обязательном порядке создать несколько собственных методов
        static void Main(string[] args)
        {
            bool p = true; // переменная для работы основного цикла программы
            while (p) // основной цикл программы
            {
                Console.WriteLine("Что бы узнать количество групп нажмите - 1.\nЧто бы создать файл с группами нажмите - 2.\nДля выхода нажмите - 3.\n");
                switch (Console.ReadLine())
                {
                    case "1": // выбор показать только кол-во групп
                        {
                            Int32.TryParse(FR(), out int N); // проверка на наличие файла
                            if (0 < N && N < 1_000_000_001)
                            {
                                DateTime start = DateTime.Now;
                                Console.Clear();
                                int M = (int)Math.Log(N, 2) + 1;
                                DateTime end = DateTime.Now;
                                string milliseconds = Math.Round(end.Subtract(start).TotalMilliseconds, 2).ToString();
                                Console.WriteLine($"Потратил времени: {milliseconds} милисекунд");
                                Console.WriteLine($"В диапазоне до {N}, получится {M} групп(ы).\n\nДля Возврата в главное меню нажмите любую кнопку");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else { EE("Число не входит в диапазон от 1 до 1 000 000 000"); break; }  // в файле не верная инфо
                        }
                    case "2": // выбор с отображением и возможностью архивации
                        {
                            Int32.TryParse(FR(), out int N); // проверка на наличие файла
                            //int N = int.Parse(Console.ReadLine()); // Временная строка для ввода N
                            if (0 < N && N < 1_000_000_001)
                            {
                                //Console.WriteLine("Введите путь к файлу записи:\n");
                                string fileName = "text.txt";//Console.ReadLine();
                                int n = 2;
                                string line="1";
                                DateTime start = DateTime.Now;
                                for (int i = 2; i < N+1; i++)
                                {
                                    if (n == i)
                                    {
                                        FW(line, fileName);
                                        line = "";
                                        line = line + $"{i} ";
                                        n *= 2;
                                    }
                                    else
                                    {
                                        line = line + $"{i} ";
                                    }
                                }
                                FW(line, fileName);
                                DateTime end = DateTime.Now;
                                string milliseconds = Math.Round(end.Subtract(start).TotalMilliseconds, 2).ToString();
                                Console.WriteLine($"Потратил времени: {milliseconds} милисекунд");
                                break;
                            }
                            else { EE("Число не входит в диапазон от 1 до 1 000 000 000"); break; }  // в файле не верная инфо
                        }
                    case "3": { p = false; break; } //  выбор для выхода из программы
                    default: { EE("Не верный ввод."); break; } // выбор для обработки ошибочных вводов
                }
            }
        }
        /// <summary>
        /// метод записи строки в файл
        /// </summary>
        /// <param name="message">что записать</param>
        /// <param name="fileName">куда записать</param>
        /// <param name="Count">Сколько записано</param>
        public static void FW(string message, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true)) {sw.WriteLine(message);}
        }
        /// <summary>
        /// метод для считывания файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FR()
        {
            string line = "";
            while (true)
            {
                Console.WriteLine("Введите путь к файлу с числом:"); string pathFile = Console.ReadLine();// ввод пути к файлу
                if (File.Exists(pathFile))
                { using (StreamReader sr = new StreamReader(pathFile)) { line = sr.ReadToEnd(); } break; }
            }
            return line;
        }
        /// <summary>
        /// Метод для ответа на ошики ввода
        /// </summary>
        /// <param name="message"></param>
        public static void EE(string message)
        {
            Console.WriteLine($"{message}\nНажмите любую кнопку.");
            Console.ReadKey(); Console.Clear();
        }
        /// <summary>
        /// метод архивирования файла
        /// </summary>
        /// <param name="path"></param>
        public static void CompressZip(string path)
        {
            string compressed = @"D:\temp\file.zip";


            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (FileStream zipfileStream = File.Create(compressed))
                {
                    using (GZipStream gZipStream = new GZipStream(zipfileStream, CompressionMode.Compress))
                    {
                        fileStream.CopyTo(gZipStream);
                        Console.WriteLine($"\nСжатие файла {path} завершено." +
                            $"\n Размер файла иходного : {fileStream.Length} " +
                            $"\n Размер файла сжатого :{zipfileStream.Length} ");
                    }
                }
            }
        }
    }
}
/// <summary>
/// попытка решить через зубчатый массив. Работает но очень долго.
/// </summary>
class BadSolution
{
    static void BadProg()
    {
        int N; // временное задание числа
        DateTime date = DateTime.Now;
        int grCount = 1; //  переменная для создания массива  mass
        while (true) // основной цикл программы
        {
            Console.WriteLine("Введите путь к файлу:");
            string path = Console.ReadLine();
            if (File.Exists(path)) // программа продолжает выполняться если файл существует
            {
                Int32.TryParse(FR(path), out N);
                if (0 < N && N < 1_000_000_000)
                {
                    int[][] groups = new int[grCount][]; // массив mass для хранения груп чисел
                    groups[0] = new int[] { 1 };  // первая группа всегда из единицы
                    for (int n = 2; n < N; n++)
                    {
                        bool c = true;
                        for (int tempCount = 0; tempCount < grCount; tempCount++)
                        {
                            if (Check(groups[tempCount], n)) // если делимости нет
                            {
                                Array.Resize(ref groups[tempCount], groups[tempCount].Length + 1); // добавляется ячейка в массив группы
                                groups[tempCount][groups[tempCount].Length - 1] = n; // добавляется значение в группу
                                c = false;
                                break;
                            }
                        }
                        if (c)
                        {
                            grCount++;
                            Array.Resize(ref groups, grCount);
                            groups[grCount - 1] = new int[] { n };
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Файл найден, но значение в нем не верно. Нажмите любую кнопку.");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден. Нажмите любую кнопку.");
            }

            DateTime past = DateTime.Now;
            string milliseconds = Math.Round(past.Subtract(date).TotalMilliseconds, 2).ToString();
            Console.WriteLine($" потратил времени: {milliseconds}");
            Console.WriteLine($"Групп получилось:  {grCount}");
            Console.ReadKey();
        }



    }
    /// <summary>
    /// метод для считывания файла
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string FR(string path)
    {
        string line;
        using (StreamReader sr = new StreamReader(path)) { line = sr.ReadToEnd(); }
        return line;
    }

    /// <summary>
    /// метод проверки очередного числа на делимость без остатка
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private static bool Check(int[] mass, int n)
    {
        foreach (int item in mass)
        {
            return false == (n % item == 0 || item % n == 0);
        }
        return true;
    }
}
