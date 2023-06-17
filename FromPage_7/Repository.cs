using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        //public Worker[] GetAllWorkers()
        //{
        //    //public Worker[] GetAllWorkers()
        ////         {
        ////                // здесь происходит чтение из файла
        ////                // и возврат массива считанных экземпляров
        ////         }
        //    string[] list;
        //    int count;
        //    if (File.Exists(fileName))
        //    {
        //        using (StreamReader sr = new StreamReader(fileName))
        //        {
        //            list = sr.ReadToEnd().Split('#');
        //        }
        //        count = ((list.Length + 1) / 7);
        //    }
        //    else
        //    {
        //        count = 0;
        //    }


        //}

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
