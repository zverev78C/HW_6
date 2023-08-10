using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromPage_7
{
    internal struct Worker
    {
        #region автосвойства

        /// <summary>
        /// номер записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// ФИО работника
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int YearsOld { get; set; }

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceOfBirth { get; set; }
        #endregion

        #region Конструктор
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="id">индекс записи</param>
        /// <param name="dateTime">время добавления записи</param>
        /// <param name="fio">Ф.И.О. сотрудника</param>
        /// <param name="yearsOld">Возраст</param>
        /// <param name="height">Вес</param>
        /// <param name="dob">Дата рождения</param>
        /// <param name="pob">Место рождения</param>
        public Worker(int id, DateTime dateTime, string fio, int yearsOld,  int height, DateTime dob, string pob)
        {
            this.Id = id;
            this.DateTime = dateTime;
            this.Fio = fio;
            this.YearsOld = yearsOld;   
            this.Height = height;
            this.DateOfBirth = dob;
            this.PlaceOfBirth = pob;
        }

        #endregion

        /// <summary>
        /// метод вывода данных о сотруднике 
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.Id,4}\t {this.DateTime:F}\t {this.Fio,15} {this.YearsOld,9} {this.Height,9}\t   {this.DateOfBirth:dd.MM.yyyy} {this.PlaceOfBirth,20}";
        }
    }
}
