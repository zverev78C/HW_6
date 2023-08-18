using System;
using System.Diagnostics.Eventing.Reader;

namespace Homework_07
{
    class Events
    {

        #region Свойства события

        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string Place { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DeadLine
        {
            //get; set;
            get
            {
                if (Date < DateTime.Now)
                {
                    return "Прошло"; 
                }
                else if (Date > DateTime.Now)
                {
                    return "Впереди";
                }
                return "Сегодня"; }
            set
            { }
        } //= "не понятно";

        public bool Status { get; set; } = false;
        #endregion



        /// <summary>
        /// Конструктор события
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="place">Место</param>
        /// <param name="name">Имя</param>
        /// <param name="description">Описание события</param>
        public Events(int ID, DateTime Date, string Place, string Name, string Description, string DeadLine, bool Status)
        {
            this.ID = ID;
            this.Date = Date; // 
            this.Place = Place;
            this.Name = Name;
            this.Description = Description;
            this.DeadLine = DeadLine;
            this.Status = Status; // 
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

    }
}
