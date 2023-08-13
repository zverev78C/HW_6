using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            bool flag = true;
            

            // обработчик ошибок проверить как работает
            while (flag == true)
            {
                Console.WriteLine("Ежедневник\n");
                Console.WriteLine($"Сегодня: {DateTime.Now:dd.MM.yyyy}");

                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Не верный выбор дествия.");
                        Console.ReadKey();
                        break;
                }
               // Console.ReadKey();
            }
        }
    }
}
