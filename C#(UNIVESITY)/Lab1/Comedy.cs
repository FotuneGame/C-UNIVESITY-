using System;


namespace Movie
{

    internal class Comedy : AFilm
    {

        public int countPopcorn { get; }



        public Comedy()
        {
            country = "Страны нет"; name = "Названия нет"; director = "Режисёра нет"; time = 0; countPopcorn = 0;
        }
        public Comedy(int countPopcorn)
        {
            this.countPopcorn = countPopcorn;
        }


        public override string ToString()
        {
            return $"Страна: {country}, Название: {name}, Директор: {director}, Длительность: {time}, Кол-во попкорна: {countPopcorn}";
        }

        public void eatPopcorn(int id_window)
        {
            Console.WriteLine("Хрум зрум поели задорно попкорн");
        }
        public override void getName(int id_window)
        {
            Console.WriteLine("Класс Комедия...");
        }
    }
}
