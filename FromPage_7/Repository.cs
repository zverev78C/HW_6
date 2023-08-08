using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FromPage_7
{
    class Repository
    {
        #region что нужно сделать

        //Создайте класс Repository, который будет отвечать за работу с экземплярами Worker.
        //        В репозитории должны быть реализованы следующие функции:

        //        Просмотр всех записей.
        //        Просмотр одной записи.Функция должна на вход принимать параметр ID записи, которую необходимо вывести на экран.

        //        Создание записи.
        //        Удаление записи.
        //        Загрузка записей в выбранном диапазоне дат.
        //        Структура класса Repository примерно такая:

        //    
        //       
        //      

        //        Имя файла должно храниться в приватном поле Repository.
        //        Файл, который использует репозиторий, должен выглядеть примерно так:

        //          1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
        //          2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск
        #endregion


        private readonly string fileName; // расположение файла
        private int count; // до считывания файла счетчик записий равен нулю
        private Worker[] workers;  // основной массив данных о сотрудниках
        private string[] args; // массив для временных действий
        private int id; // переменная для присвоения ID новому сотруднику т.к. айди и номер записи со временем могут разойтись в значениях из-за удаления некоторых записий.  

        #region Конструктор
        public Repository(string fileName)
        {
            this.fileName = fileName;
            this.workers = new Worker[1];

        }
        #endregion

        #region готовые методы работы с базой 

        /// <summary>
        /// Метод для создания файла 
        /// </summary>
        /// <param name="fileName">расположение файла</param>
        public void FirstLaunchProgramm()
        {
            using (StreamWriter sw = new StreamWriter(this.fileName, true)) { };
        }

        /// <summary>
        /// здесь происходит чтение из файла и возврат массива считанных экземпляров   
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            using (StreamReader sr = new StreamReader(this.fileName))
            {
                this.count = 0; // пока не точно но кажется понадобиться
                while (!sr.EndOfStream)
                {
                    args = sr.ReadLine().Split('#');
                    Add(new Worker
                        (Convert.ToInt32(args[0]), //id
                        Convert.ToDateTime(args[1]), // Время добавления
                        args[2], // ФИО
                        Age(Convert.ToDateTime(args[5])), // Возраст
                        Convert.ToInt32(args[4]), // рост
                        Convert.ToDateTime(args[5]), // дата рождения
                        args[6] // место рождения
                        ));
                    this.id = Convert.ToInt32(args[0]);
                }
            }
            return this.workers;
        }

        /// <summary>
        /// Метод добавления нового сотрудника.  
        /// </summary>
        /// <param name="fileName"></param>
        public void AddWorker()
        {
            this.id = count == 0 ? (this.workers[count].Id + 1) : (this.workers[count - 1].Id + 1); // счетчик сотрудников чтобы вводить коректный ID  в поле нового сотрудника

            // опрос пользователя для ввода данных о работнике
            this.args = new[] { "ID", "FIO", "Heght", "DateOfBirth", "PlaceOfBirth" };
            args[0] = Convert.ToString(this.id);
            Console.Write("Фамилия И.О. сотрудника:");
            args[1] = Console.ReadLine();
            Console.Write("Рост сотрудника:");
            args[2] = Console.ReadLine();
            Console.Write("Дата рождения сотрудника:");
            args[3] = Console.ReadLine();
            Console.Write("Место рождения сотрудника:");
            args[4] = Console.ReadLine();

            // создание строки для записи в файл
            string line = ($"{args[0]}#" +                  // ID
                $"{DateTime.Now}#" +                        // Время добавления
                $"{args[1]}#" +                             // ФИО
                $"{Age(Convert.ToDateTime(args[3]))}#" +    // Возраст
                $"{args[2]}#" +                             // вес
                $"{args[3]}#" +                             // дата рождения
                $"{args[4]}");                              // место рождения

            SaveWorker(line);
        }

        /// <summary>
        /// Метод для вывода всей базы сотрудников в консоль
        /// </summary>
        /// <param name="strings">массив сотрудников</param>
        public void PrintAll()
        {
            if (this.workers == null) // проверка ну пустую базу сотрудников при выводе в консоль
            {
                Console.WriteLine("Файл пуст");
            }
            else
            {
                PrintTitles();
                for (int i = 0; i < count; i++)
                {
                    Print(i);
                }
            }
        }

        /// <summary>
        /// Метод поиска сотрудника по его ID 
        /// </summary>
        /// <param name="ID"></param>
        public void GetWorkerById(int ID)
        {
            PrintTitles();
            int idx = -1;
            for (int i = 0; i < count; i++)
            {
                if (workers[i].Id == ID)
                {
                    idx = i;
                    Print(i);
                }
            }
            if (idx == -1) { Console.WriteLine("Такой сотрудник не обнаружен"); };
        }

        /// <summary>
        /// Метод удаления сотрудника из списка по ID  
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteWorker(int ID)
        {
            // очистка файла перед записью массива
            using (StreamWriter sw = new StreamWriter(this.fileName, false))
            {
                sw.Write(" ");
            } 
            // запись массива без указаного сотрудника 
            for (int i = 0; i < count; i++)
            {
                if (workers[i].Id == ID) // совпадение по ID
                {

                }
                else // не совпадение по ID
                {
                   string line = $"{workers[i].Id}#" +
                        $"{workers[i].DateTime}#" +
                        $"{workers[i].Fio}#" +
                        $"{workers[i].YearsOld}#" +
                        $"{workers[i].Height}#" +
                        $"{workers[i].DateOfBirth}#" +
                        $"{workers[i].PlaceOfBirth}";
                    SaveWorker(line);
                }
            }
        }




        /// <summary>
        /// Метод для выведения в консоль одного сотрудника
        /// </summary>
        /// <param name="i">индекс массива сотрудников</param>
        private void Print(int i)
        {
            Console.WriteLine(this.workers[i].Print());
        }

        /// <summary>
        /// Метод для определения возроста сотрудника
        /// </summary>
        /// <param name="dateOfBirth">дата рождения</param>
        /// <returns></returns>
        private int Age(DateTime dateOfBirth)

        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear) age--;
            return age;
        }

        /// <summary>
        /// Метод добавления сотрудника в массив
        /// </summary>
        /// <param name="ConcreteWorker">Сотрудник</param>
        private void Add(Worker ConcreteWorker)
        {
            if (count >= this.workers.Length) // проверка длины массива 
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
            this.workers[count] = ConcreteWorker; // добавление работника в массив
            this.count++;
        }

        /// <summary>
        /// Метод для выведения заголовков в консоль
        /// </summary>
        private void PrintTitles()
        {
            string[] Titles = new string[7];
            Titles[0] = "ID";
            Titles[1] = "Время создания записи";
            Titles[2] = "Фамилия И.О.";
            Titles[3] = "Возраст";
            Titles[4] = "Рост";
            Titles[5] = "Дата Рождения";
            Titles[6] = "Место Рождения";

            Console.WriteLine($"{Titles[0],4}\t {Titles[1],23} {Titles[2],17} {Titles[3],8} {Titles[4],8} {Titles[5],17} {Titles[6],19}\n");
        }

        /// <summary>
        /// Метод записи строки непосредственно в файл
        /// </summary>
        /// <param name="line">строка для записи</param>
        /// <param name="Flag">метод записи</param>
        private void SaveWorker(string line)
        {
            using (StreamWriter sw = new StreamWriter(this.fileName, true))
            {
                sw.WriteLine(line);
            }
        }


        #endregion

        #region методы для работы с базой 

        public void GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            PrintTitles();
            int idx = -1;
            for (int i = 0; i < count; i++)
            {
                if (workers[i].DateTime > dateFrom && workers[i].DateTime < dateTo)
                {
                    idx = i;
                    Print(i);
                }
            }
            if (idx == -1) { Console.WriteLine("Такой сотрудник не обнаружен"); };
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
        }


        public void SortingByCondition (string condition) 
        {
        
        }
        #endregion



    }
}
