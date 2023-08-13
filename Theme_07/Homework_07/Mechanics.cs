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
            using (StreamWriter sw = new StreamWriter(this.fileName, true)) { };
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

        public Events[] GetAllEvents()
        {
            using (StreamReader sr = new StreamReader(this.fileName)) 
            {
                count = 0;
                while (!sr.EndOfStream)
                {
                   string[] args = sr.ReadLine().Split('#');
                    if (count >= this.events.Length) // проверка длины массива 
                    {
                        Array.Resize(ref this.events, this.events.Length * 2);
                    }
                    events[count] = new Events (Convert.ToDateTime(args[0]),args[1], args[2],args[3]); // добавление работника в массив
                    this.count++;
                }
            }
            return events;
        }
    }
}
