using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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

        #region Заголовки
        /// <summary>
        /// Метод для выведения заголовков в консоль
        /// </summary>
        public void PrintTitles()
        {
            string [] Titles = new string [7];
            Titles[0] = "ID";
            Titles[1] = "Время создания записи";
            Titles[2] = "Фамилия И.О.";
            Titles[3] = "Возраст";
            Titles[4] = "Рост";
            Titles[5] = "Дата Рождения";
            Titles[6] = "Место Рождения";

            Console.WriteLine($"{Titles[0],4}\t {Titles[1],23} {Titles[2],20} {Titles[3],8} {Titles[4],8} {Titles[5],15} {Titles[6],15}");
        }
        #endregion 

        private readonly string fileName; // расположение файла
        private int index; // до считывания файла счетчик записий равен нулю
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
        /// Метод для вывода всей базы сотрудников в консоль
        /// </summary>
        /// <param name="strings">массив сотрудников</param>
        public void Print(Worker[] strings)
        {
            if (strings == null) // проверка ну пустую базу сотрудников при выводе в консоль
            {
                Console.WriteLine("Файл пуст");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine(this.workers[i].Print());
                }
            }
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
        /// здесь происходит чтение из файла и возврат массива считанных экземпляров 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            using (StreamReader sr = new StreamReader(this.fileName))
            {
                this.index = 0; // пока не точно но кажется понадобиться
                while (!sr.EndOfStream)
                {
                    args = sr.ReadLine().Split('#');
                    Add(new Worker
                        (Convert.ToInt32(args[0]), //id
                        Convert.ToDateTime(args[1]), // Время добавления
                        args[2], // ФИО
                        Age(Convert.ToDateTime(args[5])), // Возраст
                        Convert.ToInt32(args[4]), // вес
                        Convert.ToDateTime(args[5]), // дата рождения
                        args[6] // место рождения
                        ));
                    this.id = Convert.ToInt32(args[0]);
                }
            }
            return this.workers;
        }

        /// <summary>
        /// Метод добавления сотрудника в хранилище
        /// </summary>
        /// <param name="ConcreteWorker">Сотрудник</param>
        public void Add(Worker ConcreteWorker)
        {
            if (index >= this.workers.Length)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
            this.workers[index] = ConcreteWorker;
            this.index++;
        }

        /// <summary>
        /// Метод добавления нового сотрудника. (надо доделать присвоение ID) 
        /// </summary>
        /// <param name="fileName"></param>
        public void AddWorker()
        {
            this.id++;
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

            
            string line = ($"{args[0]}#" +                  // ID
                $"{DateTime.Now}#" +                        // Время добавления
                $"{args[1]}#" +                             // ФИО
                $"{Age(Convert.ToDateTime(args[3]))}#" +    // Возраст
                $"{args[2]}#" +                             // вес
                $"{args[3]}#" +                             // дата рождения
                $"{args[4]}");                              // место рождения

            using (StreamWriter sw = new StreamWriter(this.fileName, true))
            {
                sw.WriteLine(line);
            }
        }

        #endregion

        #region методы для работы с базой 

        //            public Worker GetWorkerById(int id)
        //         {
        //                // происходит чтение из файла, возвращается Worker
        //                // с запрашиваемым ID
        //         }

        //            public void DeleteWorker(int id)
        //         {
        //                // считывается файл, находится нужный Worker
        //                // происходит запись в файл всех Worker,
        //                // кроме удаляемого
        //         }
        //            public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        //         {
        //                // здесь происходит чтение из файла
        //                // фильтрация нужных записей
        //                // и возврат массива считанных экземпляров
        //         }

        #endregion



    }
}
