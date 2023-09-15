using System;


namespace Movie
{
    abstract internal class AFilm: IFilm
    {
        public string country { set; get; }
        public string name { set; get; }
        public string director { set; get; }
        public int time { set; get; }

        public  void write(int id_window)
        {
            Console.WriteLine("Страна:");
            this.country = Console.ReadLine();
            Console.WriteLine("Название:");
            this.name = Console.ReadLine();
            Console.WriteLine("Директор:");
            this.director = Console.ReadLine();

            int time_new;
            Console.WriteLine("Продолжительность:");
            string str = Console.ReadLine();

            if (System.Int32.TryParse(str, out time_new) && time_new >= 0 && time_new < 900)
            {
                this.time = time_new;
            }
            else
                Console.WriteLine("Не соответствует вводу длительности");
            Console.ReadLine();
            Console.Clear();
        }
        public  void read(int id_window)
        {
            Console.WriteLine(this);
            Console.ReadLine();
            Console.Clear();
        }

        public virtual void getName(int id_window)
        {
            Console.WriteLine("Абстрактный класс Фильм");
        }
    }
}
