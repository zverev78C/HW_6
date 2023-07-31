using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromPage_7
{
    internal class Program
    {
        #region Что нужно сделать
        //Улучшите программу, которую разработали в модуле 6. Создайте структуру Worker со следующими свойствами:

        //  ID
        //  Дата и время добавления записи
        //  Ф.И.О.
        //  Возраст
        //  Рост
        //  Дата рождения
        //  Место рождения

        //  Структура будет выглядеть примерно так:
        //    struct Worker
        //    {
        //            public int Id { get; set; }
        //            public string FIO { get; set; }
        //    … другие свойства
        //    }

        //        Создайте класс Repository, который будет отвечать за работу с экземплярами Worker.
        //        В репозитории должны быть реализованы следующие функции:

        //        Просмотр всех записей.
        //        Просмотр одной записи.Функция должна на вход принимать параметр ID записи, которую необходимо вывести на экран.

        //        Создание записи.
        //        Удаление записи.
        //        Загрузка записей в выбранном диапазоне дат.
        //        Структура класса Repository примерно такая:

        //      class Repository
        //      {
        //            public Worker[] GetAllWorkers()
        //         {
        //                // здесь происходит чтение из файла
        //                // и возврат массива считанных экземпляров
        //         }

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
        //      }

        //        Имя файла должно храниться в приватном поле Repository.Файл, который использует репозиторий, должен выглядеть примерно так:
        //          1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
        //          2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск
        //…

        //        Используя структуру Worker и класс Repository, в основном методе Main реализуйте программу для работы с записями.
        //        Также предоставьте пользователю возможность сортировать данные по разным полям.

        //        При желании можете дополнить программу следующим функционалом:
        //        Редактирование записей.
        //        Генерация запрашиваемого количества записей из кода (в качестве имени можно использовать строки типа «Имя1», «Имя2», …).
        //        Свой функционал.

        //          Советы и рекомендации
        //          Обратите внимание, что в строке есть символ # — разделитель. 
        //          Символа # не должно быть при чтении (разбить строку на массив поможет разделение строк с помощью метода String.Split).
        //          Создайте методы для работы с записями.
        //          Файла изначально нет, поэтому программа при первом запуске должна его создать, чтобы не было ошибки.
        //          Сортировку по полям удобнее всего выполнять с помощью метода OrderBy. Пример сортировки по FIO и по ID:
        //          workers.OrderBy(w=>w.FIO);
        //          workers.OrderBy(w => w.Id);
        #endregion

        static void Main(string[] args)
        {
            string fileName = "list.csv"; // расположение файла
            bool flag = true; // Переменная для закрытия программы
            Repository rep = new Repository(fileName); // инициализируем репозиторий для работы с базой данных

            // Проверка на наличие файла
            if (File.Exists(fileName) == false) // если файла не существует то создаем его 
            {
                rep.FirstLaunchProgramm();
            }

            while (flag == true)
            {
                rep.GetAllWorkers(); // Заполнение массива из файла

                Console.WriteLine("Справочник «Сотрудники» \n" +
                    " Нажмите 1 - для просмотра всех сотрудников\n" +
                    " Нажмите 2 - для поиска сотрудников\n" +
                    " Нажмите 3 - для удаления записи сотрудника\n" +
                    " Нажмите 4 - Поиск сотрудников по дате\n" +
                    " Нажмите 9 - для добавления нового сотрудника\n" +
                    " Нажмите 10 - для выхода из программы\n");

                switch (Console.ReadLine())
                {
                    // выбор просмотра списка всех сотрудников в базе
                    case "1":
                        Console.Clear();
                        rep.PrintAll();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    // поиск сотрудника
                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("Введите необходимый ID:");
                            int idFound = Convert.ToInt32(Console.ReadLine());
                            rep.GetWorkerById(idFound);
                            Console.ReadKey();
                            break;
                        }
                    // удаление сотрудника
                    case "3":
                        {
                            Console.Clear();
                            Console.WriteLine("Введите необходимый ID:");
                            int idDel = Convert.ToInt32(Console.ReadLine());
                            rep.DeleteWorker(idDel);
                            break;
                        }
                    // Поиск по дате 
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Введите дату начала поиска");
                            DateTime dateFrom = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Введите дату конца поиска");
                            DateTime dateTo = Convert.ToDateTime(Console.ReadLine());
                            rep.GetWorkersBetweenTwoDates(dateFrom, dateTo);    
                            break;
                        }
                    // Пустой выбор
                    case "5":
                        {

                            break;
                        }
                    // Пустой выбор
                    case "6":
                        {
                            break;
                        }
                    // выбор добавления нового сотрудника в список
                    case "9":
                        rep.AddWorker();
                        rep.GetAllWorkers();
                        Console.Clear();
                        break;
                    //выход из программы 
                    case "10":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Не верный выбор попробуйте еще раз:");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}

