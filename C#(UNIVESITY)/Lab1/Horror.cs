using System;

namespace Movie
{
    sealed internal class Horror : AFilm
    {


        public int countTicket{ get; }



        public Horror()
        {
            country = "Страны нет"; name = "Названия нет"; director = "Режисёра нет"; time = 0; countTicket = 0;
        }
        public Horror(int countTicket)
        {
            this.countTicket = countTicket;
        }


        public override string ToString()
        {
            return $"Страна: {country}, Название: {name}, Директор: {director}, Длительность: {time}, Кол-во билетов: {countTicket}";
        }

        public void countTicketNow(int id_window)
        {
            Console.WriteLine("Билетов: " + countTicket);
        }
        public override void getName(int id_window)
        {
            Console.WriteLine("Класс Ужасы...");
        }
    }
}
