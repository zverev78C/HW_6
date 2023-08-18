using System;
using System.IO;

namespace Homework_07
{
    class Program
    {
        static void Main()
        {
            #region что надо сделать
            /// Разработать ежедневник.
            /// В ежедневнике реализовать возможность 
            /// - создания
            /// - удаления
            /// - реактирования записей
            /// 
            /// В отдельной записи должно быть не менее пяти полей
            /// 
            /// Реализовать возможность 
            /// - Загрузки даннах из файла
            /// - Выгрузки даннах в файл
            /// - Добавления данных в текущий ежедневник из выбранного файла
            /// - Импорт записей по выбранному диапазону дат
            /// - Упорядочивания записей ежедневника по выбранному полю
            #endregion


            bool flag = true; //переменная для завершения программы
            Mechanics mech = new Mechanics(); //Инициализируем класс механики программы
            mech.FirstLaunchProgramm();  // проверка на наличие файла в директории
                mech.GetAllEvents();

            while (flag == true)
            {
                Console.WriteLine("\nЕжедневник\n");
                Console.WriteLine($"Сегодня: {DateTime.Now:dd.MM.yyyy}\n ");
                mech.MainMenu();

                switch (Console.ReadLine())
                {
                    case "1": // вывод на экран всех событий в базе данных
                        Console.Clear();
                        mech.PrintAllEvents();
                        Console.ReadKey();
                        break;
                    case "2": // Создание новой записи
                        mech.NewEvent();
                        Console.Clear();
                        break;
                    case "3": // удаление записи
                        break;
                    case "4": // редактирование записи
                        break;
                    case "5": // выход из программы
                        mech.SaveArroy();
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Не верный выбор дествия.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
