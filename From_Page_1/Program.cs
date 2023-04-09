using System;
using System.Collections.Generic;
using System.IO;

namespace From_Page_1
{
    #region
    //    Что нужно сделать
    //Создайте справочник «Сотрудники».

    //Разработайте для предполагаемой компании программу, которая будет добавлять записи новых сотрудников в файл.
    //Файл должен содержать следующие данные:

    //ID
    //Дату и время добавления записи
    //Ф.И.О.
    //Возраст
    //Рост
    //Дату рождения
    //Место рождения
    //Для этого необходим ввод данных с клавиатуры.После ввода данных:

    //если файла не существует, его необходимо создать;
    //    если файл существует, то необходимо записать данные сотрудника в конец файла.
    //    При запуске программы должен быть выбор:


    //    введём 1 — вывести данные на экран;
    //    введём 2 — заполнить данные и добавить новую запись в конец файла.


    //    Файл должен иметь следующую структуру:

    //1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
    //2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск
    //…


    //Советы и рекомендации
    //Обратите внимание, что в строке есть символ # — разделитель в строке. При чтении файла необходимо убрать символ #.
    //Разбить строку на массив элементов поможет разделение строк с помощью метода String.Split.
    //Разбейте программу на методы(чтение, запись).
    //Новую запись внесите в конец файла.
    //Проверьте, создан файл или нет.


    //Что оценивается
    //Структура файла после добавления сотрудника идентична.
    //Каждый метод выполняет одну задачу.
    //Запись корректно выводится в консоль.
    //Файл корректно закрывается после записи и чтения.

    #endregion

    internal class Program
    {
        /// <summary>
        /// метод для чтения файла
        /// </summary>
        /// <param name="fileName"></param>
        static void ReadF(string fileName)
        {
            Console.Clear();
            string list;
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    list = sr.ReadToEnd();
                }
                list = list.Replace("#", " ");
                Console.WriteLine(list);
            }
            else
            {
                Console.WriteLine("Файл еще не существует, выберите создать первую запись ");
            }
            Console.WriteLine();
            Console.WriteLine("Для продожения нажмите любую кнопку...");
            Console.ReadKey();
        }
        /// <summary>
        /// метод для записи файла
        /// </summary>
        /// <param name="fileName"></param>
        static void WriteF(string fileName)
        {
            // часть первая считать файл для получения значения очередного номера записи
            string[] list;
            int count;
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    list = sr.ReadToEnd().Split('#');
                }
                count = ((list.Length + 1) / 7);
            }
            else
            {
                count = 0;
            }

            // часть вторая метода опрос пользователя и запись данных в файл
            string line = $"{count + 1}#{DateTime.Now}#{ask("Фаимилия Имя Отчество")}" +
                $"#{ask("Возрост")}#{ask("Рост")}#{ask("Дата рождения")}#{ask("Место рождения")}";

            string ask(string text)
            {
                Console.WriteLine(text);
                return Console.ReadLine();
            } // внутрений метод для считывания данных пользователя

            Console.WriteLine(line);
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(line);
            }

        }



        static void Main(string[] args)
        {
            string fileName = "list.csv"; // расположение файла
            while (true)
            {
                Console.WriteLine("Справочник «Сотрудники» \n Нажмите 1 - для просмотра сотрудников\n" +
                    " Нажмите 2 - для добавления нового сотрудника\n" +
                    " нажмите 3 - Для выхода из программы");
                string chose = Console.ReadLine();
                if (chose == "1")
                {
                    ReadF(fileName);
                    Console.Clear();
                }
                else if (chose == "2")
                {
                    WriteF(fileName);
                    Console.Clear();
                }
                else if (chose == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Не верный выбор попробуйте еще раз:");
                    Console.Clear();
                }
            }
        }
    }
}
