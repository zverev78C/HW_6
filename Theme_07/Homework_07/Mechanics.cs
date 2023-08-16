using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Homework_07
{
    class Mechanics
    {

        // Место храннеия файла для записи событий
        private readonly string fileName = "Events.txt";
        private int count;
        private int id;
        Events[] events;

        public Mechanics()
        {
            this.events = new Events[1];
        }

        /// <summary>
        /// Метод первого запуска программы для создания файла храниения данных   
        /// </summary>
        public void FirstLaunchProgramm()
        {
            if (File.Exists(fileName) == false)
            {
            using (StreamWriter sw = new StreamWriter(this.fileName, true)) { };
            }
        }

        /// <summary>
        /// Метод вывода на консоль главного меню программы  
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("Для работы с Ежедневником выберите одно из следующих действий:\n" +
                " \n " +
                "нажмите 1 Для вывода всех записей Ежеднкевника \n " +
                "нажмите 2 Для Создания новой записи\n " +
                "нажмите 3 Для удаления записи\n " +
                "нажмите 4 Для редактирования записи\n " +
                "нажмите 5 Для выхода из прогрмаммы\n");
        }

        /// <summary>
        /// Метод считывания из файла всех событий
        /// </summary>
        /// <returns></returns>
        public Events[] GetAllEvents()
        {
            using (StreamReader sr = new StreamReader(this.fileName))
            {
                count = 0;
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    id = Convert.ToInt32(args[0]); // обновляем актуальный номер записи
                    AddToArroy (args); // передаем строку для записи в массив
                }
            }
            return events;
        }

        public void PrintAllEvents()
        {
            if (events[0] == null)
            {
                Console.WriteLine("Событий в базе не найденно");
            }
            else
            {
                foreach (Events e in events)
                {
                    Console.WriteLine(e.PrintShort());
                }
            }
            
        }

        /// <summary>
        /// метод добавления события
        /// </summary>
        /// <returns></returns>
        public Events[] NewEvent()
        {
            string[] args = new string[6];

            args[0] = Convert.ToString(id);
            Console.WriteLine("Введите дату начала события");
            args[1] = Console.ReadLine();
            Console.WriteLine("Введите место проведения события");
            args[2] = Console.ReadLine();
            Console.WriteLine("Введите название события");
            args[3] = Console.ReadLine();
            Console.WriteLine("Введите описание события");
            args[4] = Console.ReadLine();
            args[5] = Convert.ToString (false);
            AddToArroy( args);
            return events;
        }

        /// <summary>
        /// Метод редактирование события
        /// </summary>
        /// <param name="ID"></param>
        public void EditEvent(int ID)
        {

        }

        /// <summary>
        /// Метод удаления события
        /// </summary>
        public void DeleteEvent()
        {

        }

        /// <summary>
        /// Метод добавления события в массив
        /// </summary>
        /// <param name="args"></param>
        private void AddToArroy(string[] args)
        {
            if (count >= this.events.Length) // проверка длины массива 
            {
                Array.Resize(ref this.events, this.events.Length * 2);
            }
            this.events[count] = new Events(
                        Convert.ToInt32(args[0]), // ID
                        Convert.ToDateTime(args[1]), // дата события
                        args[2], // место проведения события
                        args[3], // название события
                        args[4], // описание
                        Convert.ToBoolean (args[5])); // status
            this.count++;
        }

        /// <summary>
        /// Метод записи массива в файл
        /// </summary>
        public void SaveArroy()
        {

        }
    }
}
