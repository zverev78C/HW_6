using System;
using System.Diagnostics.Eventing.Reader;

namespace Homework_07
{
    class Events
    {

        #region Свойства события

        private int ID { get; set; }

        private DateTime Date { get; set; }

        private string DeadLine { get; set; }

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
        public Events(int id, DateTime date, string place, string name, string description, bool status)
        {
            this.ID = id;
            this.Date = date; // добавить дату окончания события
            this.Place = place;
            this.Name = name;
            this.Description = description;
            this.DeadLine = Deadline(DateTime.Now);
            this.Status = status; // Изменить на 4 пункта (действует, грядущее, просрочено)
        }

        public string PrintShort()
        {
            string status = this.Status == true ? "выполнено" : "не выполнено";
            return $"{ID} {Date:dd.MM.yyyy} {Place} {Name} {DeadLine} {status}";
        }

        public string PrintOne()
        {
            string status = this.Status == true ? "выполнено" : "не выполнено";
            return $"{Date:dd.MM.yyyy} {Place}\n \n {Name}\n {Description} \n {DeadLine} {status} ";
        }

        private string Deadline(DateTime now)
        {
            if (Date < now)
            {
                return "Впереди";
            }
            else if (Date > now)
            {
                return "Прошло";
            }
            return "Сегодня";
        }
    }
}
