using System;


namespace Movie
{
    internal class ActionMovie : AFilm
    {
        private int ratting;

        public const bool isHave = true;

        // св-ва в абстрактном классе 

        public ActionMovie() 
        {
            ratting = 0; country = "Страны нет"; name = "Названия нет"; director = "Режисёра нет"; time = 0;
        }
        public ActionMovie(int ratting, string country, string name, string director, int time)
        {
            this.ratting = ratting;
            this.country = country;
            this.name = name;
            this.director = director;
            this.time = time;
        }
        public ActionMovie(ActionMovie action)
        {
            this.ratting = action.ratting;
            this.country = action.country;
            this.name = action.name;
            this.director = action.director;
            this.time = action.time;
        }



        // ещё 2 метода наследуются 
        public void makeRatting(int id_window)
        {
            int rate;
            Console.WriteLine("Введите рейтинг:");
            string str = Console.ReadLine();

            if(System.Int32.TryParse(str,out rate) && rate>=0 && rate < 10)
            {
                ratting = rate;
            }
            else
            {
                Console.WriteLine("Рейтинг не соответствует нормам ввода!");
            }
            Console.ReadLine();
            Console.Clear();
        }



        public static void Describe(int id_window)
        {
            Console.WriteLine("ОПИСАНИЕ ЖАНРА БОЕВИК:");
            Console.WriteLine("Ну эпик, такчки, взрывы, Скала и Дуйн джонс, крч круто... ");
            Console.ReadLine();
            Console.Clear();
        }
        public override string ToString()
        {
            return $"Страна: {country}, Название: {name}, Директор: {director}, Длительность: {time}, Рейтинг: {ratting}";
        }



        //Перегрузка оператора +, оператор присваивания нельзя перегрузить!!!
        public static ActionMovie operator +(ActionMovie a) => a;



        public override void getName(int id_window)
        {
            Console.WriteLine("Класс Боевик...");
        }
    }
}
