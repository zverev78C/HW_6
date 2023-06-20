using System;
using System.Collections.Generic;
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

        string[] titles = { "ID", "Время создания записи", "Фамилия И.О.", "Возраст", "Рост", "Дата Рождения", "Место Рождения" }; // массив для хранения заголовков
        private Worker[] workers;  // основной массив данных о сотрудниках
        private int count;
        // string fileName;


        /// <summary>
        /// Метод для создания файла и записи заголовков 
        /// </summary>
        /// <param name="fileName">расположение файла</param>
        public void FirstLaunchProgramm(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true)) ;
        }

        /// <summary>
        /// Временный метод для контроля вывода в консоль
        /// </summary>
        public void PrintTitles()
        {
            Console.Clear();
            Console.Write($"{this.titles[0],5}|{this.titles[1],22}|{this.titles[2],15}|{this.titles[3],4}|{this.titles[4],4}|{this.titles[5],15}|{this.titles[6],15}");

            Console.ReadKey();
        }

        /// <summary>
        /// здесь происходит чтение из файла и возврат массива считанных экземпляров 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Worker[] GetAllWorkers(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');                     
                    Add(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]));
                }
                return this.workers;
            }
        }
        /// <summary>
        /// Метод добавления сотрудника в хранилище
        /// </summary>
        /// <param name="ConcreteWorker">Сотрудник</param>
        public void Add(Worker ConcreteWorker)
        {
            //this.Resize(count >= this.workers.Length);
            this.workers[count] = ConcreteWorker;
            this.count++;
        }
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

        //            public void AddWorker(Worker worker)
        //         {
        //                // присваиваем worker уникальный ID,
        //                // дописываем нового worker в файл
        //         }

        //            public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        //         {
        //                // здесь происходит чтение из файла
        //                // фильтрация нужных записей
        //                // и возврат массива считанных экземпляров
        //         }
    }
}
