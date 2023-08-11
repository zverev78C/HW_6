using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    class Events
    {
        /// <summary>
        /// Место храннеия файла для записи событий
        /// </summary>
        private string FileName { get; set; }

        #region Свойства события
        private DateTime Date { get;  set; }

        private string Place { get; set; }

        private string Name { get; set; }

        private string Description { get; set; }

        private bool Status { get; set; }
        #endregion

        /// <summary>
        /// Конструктор события
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="place">Место</param>
        /// <param name="name">Имя</param>
        /// <param name="description">Описание события</param>
        public Events (DateTime date, string place, string name, string description)
        {
            this.Date = date;
            this.Place = place;
            this.Name = name;
            this.Description = description;
            this.Status = false;
        }


        #region Методы работы с событиями
        public string Print ()
        {
            return $"({Date:dd.MM.yyyy} {Place} {Name} {Description} {Status})";
        }

        /// <summary>
        /// Задание место хранения файла с данными событий
        /// </summary>
        public void File ()
        {
            this.FileName = "Events.txt";
        }
        #endregion

    }
}
