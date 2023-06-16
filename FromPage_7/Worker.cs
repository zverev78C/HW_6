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


    }
}
