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
        public DateTime YearsOld { get; private set; }

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
        public Worker(int id, DateTime dateTime, string fio, DateTime yearsOld, int height, DateTime dob, string pob)
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
    }
}
