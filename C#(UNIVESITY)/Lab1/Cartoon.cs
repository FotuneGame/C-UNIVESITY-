using System;


namespace Movie
{
    internal class Cartoon : AFilm
    {
        public int countView { get; }



        public Cartoon()
        {
            country = "Страны нет"; name = "Названия нет"; director = "Режисёра нет"; time = 0; countView = 0;
        }
        public Cartoon(int countView)
        {
            this.countView  = countView;
        }


        public override string ToString()
        {
            return $"Страна: {country}, Название: {name}, Директор: {director}, Длительность: {time}, Кол-во просмотров: {countView}";
        }


        public void view(int id_window)
        {
            Console.WriteLine("Прочли фильм???");
        }
        public override void getName(int id_window)
        {
            Console.WriteLine("Класс Мультики...");
        }
    }
}
