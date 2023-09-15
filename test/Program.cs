using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace HW_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool p = true;
            while (p) // Цикл Главного меню
            {
                Console.WriteLine("Что бы узнать количество групп нажмите - 1.\nЧто бы создать файл с группами нажмите - 2.\nДля выхода нажмите - 3.\n");
                string pathFile; // Переменнная для указания пути к файлу
                int N;
                switch (Console.ReadLine())
                {
                    case "1": // выбор пользователя показать только кол0во групп
                        {
                            (pathFile, N) = FR();

                            DateTime timeStart = DateTime.Now;
                            Console.Clear();
                            int M = (int)Math.Log(N, 2) + 1;
                            TC(timeStart);
                            EE($"В диапазоне до {N}, получится {M} групп(ы).\n\n");
                            break;

                        }
                    case "2":// выбор пользователя создать файл с группами
                        {
                            (pathFile, N) = FR();
                            FWL("\nПолучившиеся группы чисел:".ToString(), pathFile); // подготовка файла к записи
                            StringBuilder line = new StringBuilder("1");
                            DateTime timeStart = DateTime.Now;
                            int n = 2;
                            for (int i = 2; i <= N; i++)
                            {
                                if (i == n) // реализация записи в файл и переноса строки при создании новой группы
                                {
                                    n *= 2;
                                    FWL(line.ToString(), pathFile);
                                    line.Clear();
                                    line.Append($"{i},");
                                }
                                else if ((i % 100_000) == 0) // защита от переполнения памяти при диапазоне в 100М+
                                {
                                    FW(line.ToString(), pathFile); // запись строки в файл без переноса строки
                                    line.Clear();
                                    line.Append($"{i},");
                                }
                                else // добовление нового числа в память
                                {
                                    line.Append($"{i},");
                                }
                            }
                            FW(line.ToString(), pathFile);
                            TC(timeStart);
                            Zip(pathFile);
                            break;
                        }
                    case "3": { p = false; break; } //  выбор для выхода из программы
                    default: { EE("Не верный ввод."); break; } // выбор для обработки ошибочных вводов
                }
            }
        }

        /// <summary>
        /// Метод Записи строки в файл С ПЕРЕНОСОМ на новую строку для создания новой группы чисел
        /// </summary>
        /// <param name="line">строка для записи</param>
        /// <param name="pathFile"> путь к файлу для записи</param>
        static void FWL(string line, string pathFile)
        {
            using (StreamWriter sw = new StreamWriter(pathFile, true)) { sw.WriteLine(line); }
        }
        /// <summary>
        /// Метод записи файла БЕЗ переноса строки
        /// </summary>
        /// <param name="line">строка для записи</param>
        /// <param name="pathFile">путь к файлу для записи</param>
        static void FW(string line, string pathFile)
        {
            using (StreamWriter sw = new StreamWriter(pathFile, true)) { sw.Write(line); }
        }
        /// <summary>
        /// Метод для архивирования файла
        /// </summary>
        /// <param name="pathFile">путь к исходному файлу</param>
        static void Zip(string pathFile) // Метод архивации файла
        {
            bool zip = true;
            while (zip)
            {
                Console.WriteLine("Хотите ли вы зарахивировать полученый файл с результатом?\n\nДа нажмите - Y.\nНет нажмите - N.");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        {
                            using (FileStream fileStream = new FileStream(pathFile, FileMode.OpenOrCreate))
                            {
                                using (FileStream zipfileStream = File.Create("file.7z"))
                                {
                                    using (GZipStream gZipStream = new GZipStream(zipfileStream, CompressionMode.Compress))
                                    {
                                        fileStream.CopyTo(gZipStream);
                                        EE($"\nСжатие файла завершено.\nРазмер файла иходного : {fileStream.Length}\nРазмер файла сжатого :{zipfileStream.Length}");
                                    }
                                }
                            }
                            zip = false;
                            break;
                        }
                    case ("n"): { zip = false; break; }
                    default: { Console.WriteLine("Выбор не понятеню"); break; }
                }

            }

        }
        /// <summary>
        /// Метод ответа на неправильный ввод
        /// </summary>
        /// <param name="message">сообшение о ошибке</param>
        public static void EE(string message)
        {
            Console.WriteLine($"{message}\nНажмите любую кнопку.");
            Console.ReadKey(); Console.Clear();
        }
        /// <summary>
        /// Метод орпеделения потраченого кол-ва времени 
        /// </summary>
        /// <param name="start">время начала отсчета</param>
        static void TC(DateTime start)
        {
            Console.WriteLine($"Потратил времени: {Math.Round(DateTime.Now.Subtract(start).TotalMilliseconds, 2)} милисекунд");
        }
        /// <summary>
        /// Метод проверяющий путь и файл на соответствие условиям задачи. Возвращает сначала путь к файлу а потом чмсло из файла
        /// </summary>
        /// <returns></returns>
        public static (string pathFile, int N) FR()
        {
            while (true)
            {
                Console.WriteLine("Введите путь к файлу с числом:\n");
                string pathFile = Console.ReadLine();
                string line;
                if (File.Exists(pathFile))
                {
                    using (StreamReader sr = new StreamReader(pathFile)) { line = sr.ReadToEnd(); }
                    if (Int32.TryParse(line, out int N))
                    {
                        if (0 < N && N < 1_000_000_001) { return (pathFile, N); }
                    }
                    else { EE("Число не входит в диапазон от 1 до 1 000 000 000"); }  // в файле не верная инфо
                }
                else
                {
                    EE("Файл не найден, попробуйте еще раз");
                }

            }

        }
    }
}
