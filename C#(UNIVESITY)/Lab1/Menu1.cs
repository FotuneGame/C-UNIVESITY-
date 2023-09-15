using System;
using System.Collections.Generic;

using MenuCUI;
using Movie;

namespace Menu1Space
{
    // класс не в иерархии но тоже реализует интерфейс IFilm
    internal class Menu1: IFilm
    {
        // список фильмов
        private List<IFilm> films = new List<IFilm>();
        private Menu menu = new Menu();

        //реализация методов интерфейса IFilm
        public void write(int id_window) { Console.WriteLine("Реализация (Класса вне иерархии) интерфейса IFilm 1"); }
        public void read(int id_window) { Console.WriteLine("Реализация (Класса вне иерархии) интерфейса IFilm 2"); }
        public void getName(int id_window) { Console.WriteLine("Реализация (Класса вне иерархии) интерфейса IFilm 3"); }




        public void MenuForOneEx()
        {
            ActionMovie action = new ActionMovie();

            Window main = new Window();

            // Создание строк
            Line main_line = new Line("Задание параметров конструируемого объекта", 0);
            Line main_line2 = new Line("Вывод свойств объекта", 0);
            Line main_line3 = new Line("Выполнение статического метода (Описание жанра)", 0);
            Line main_line4 = new Line("Выполнение методов объекта", 0);
            Line main_line5 = new Line("Выход", -1);

            // Добавление строки в окно
            main.lines.Add(main_line);
            main.lines.Add(main_line2);
            main.lines.Add(main_line3);
            main.lines.Add(main_line4);
            main.lines.Add(main_line5);

            //Привязка дополнительного события
            main_line.Events += action.write;
            main_line2.Events += action.read;
            main_line3.Events += ActionMovie.Describe;
            main_line4.Events += action.makeRatting;


            // Добавление и отображение окна
            menu.windows.Add(main);
            menu.showWindow(0);
        }

        public void MenuForTwoEx()
        {
            ActionMovie action = new ActionMovie();
            Comedy comedy = new Comedy();
            Cartoon cartoon = new Cartoon();
            Horror horror = new Horror( 100 );

            Window main = new Window();

            // Создание строк
            Line main_line = new Line("Задание свойств каждого объекта", 0);
            Line main_line2 = new Line("Вывод свойств объекта", 0);
            Line main_line3 = new Line("Вывод имени класса объекта", 1);
            Line main_line4 = new Line("Выполнение методов объекта", 0);
            Line main_line5 = new Line("Выход", -1);

            // Добавление строки в окно
            main.lines.Add(main_line);
            main.lines.Add(main_line2);
            main.lines.Add(main_line3);
            main.lines.Add(main_line4);
            main.lines.Add(main_line5);

            //Привязка дополнительного события
            main_line.Events += action.getName;
            main_line.Events += action.write;
            main_line.Events += comedy.getName;
            main_line.Events += comedy.write;
            main_line.Events += cartoon.getName;
            main_line.Events += cartoon.write;
            main_line.Events += horror.getName;
            main_line.Events += horror.write;

            main_line2.Events += action.getName;
            main_line2.Events += action.read;
            main_line2.Events += comedy.getName;
            main_line2.Events += comedy.read;
            main_line2.Events += cartoon.getName;
            main_line2.Events += cartoon.read;
            main_line2.Events += horror.getName;
            main_line2.Events += horror.read;


            Window names = new Window();
            Line names_exit = new Line("Назад", 0);
            names.lines.Add(names_exit);
            main_line3.Events += action.getName;
            main_line3.Events += comedy.getName;
            main_line3.Events += cartoon.getName;
            main_line3.Events += horror.getName;

            

            main_line4.Events += comedy.getName;
            main_line4.Events += comedy.eatPopcorn;
            main_line4.Events += cartoon.getName;
            main_line4.Events += cartoon.view;
            main_line4.Events += horror.getName;
            main_line4.Events += horror.countTicketNow;
            main_line4.Events += action.getName;
            main_line4.Events += action.makeRatting;

            // Добавление и отображение окна
            menu.windows.Add(main);
            menu.windows.Add(names);
            menu.showWindow(0);
        }

        public void MenuForThreeEx()
        {

            write(0);
            read(0);
            getName(0);

            Window main = new Window();

            // Создание строк
            Line main_line = new Line("Добавление нового объекта выбранного пользователем класса в список", 1);
            Line main_line2 = new Line("Вывод свойств объекта из списка", 0);
            Line main_line3 = new Line("Выполнение методов объекта из списка", 0);
            Line main_line4 = new Line("Вывод всех объектов в списке с указанием их классов", 0);
            Line main_line5 = new Line("Выполнение созданной функции с указанным объектом из списка", 0);
            Line main_line6 = new Line("Выход", -1);


            // Добавление строки в окно
            main.lines.Add(main_line);
            main.lines.Add(main_line2);
            main.lines.Add(main_line3);
            main.lines.Add(main_line4);
            main.lines.Add(main_line5);
            main.lines.Add(main_line6);

            main_line2.Events += readProperis;
            main_line3.Events += readMethod;
            main_line4.Events += getAllListMovie;
            main_line5.Events += RandomObjMethod;

            Window add_category = new Window();
            Line add_category_line = new Line("Боевик", 2);
            Line add_category_line2 = new Line("Ужасы", 3);
            Line add_category_line3 = new Line("Мультик", 4);
            Line add_category_line4 = new Line("Комедия", 5);
            Line add_category_line5 = new Line("Назад", 0);

            add_category_line.Events += MakeNewFilm;
            add_category_line2.Events += MakeNewFilm;
            add_category_line3.Events += MakeNewFilm;
            add_category_line4.Events += MakeNewFilm;

            add_category.lines.Add(add_category_line);
            add_category.lines.Add(add_category_line2);
            add_category.lines.Add(add_category_line3);
            add_category.lines.Add(add_category_line4);
            add_category.lines.Add(add_category_line5);

            // Добавление и отображение окна
            menu.windows.Add(main);
            menu.windows.Add(add_category);
            menu.showWindow(0);
        }


        private void MakeNewFilm(int id_window)
        {
            switch (id_window)
            {
                case 2:
                    ActionMovie action = new ActionMovie();
                    action.write(id_window);
                    films.Add(action);
                    break;
                case 3:
                    Horror horror = new Horror();
                    horror.write(id_window);
                    films.Add(horror);
                    break;
                case 4:
                    Cartoon cartoon = new Cartoon();
                    cartoon.write(id_window);
                    films.Add(cartoon);
                    break;
                case 5:
                    Comedy comedy = new Comedy();
                    comedy.write(id_window);
                    films.Add(comedy);
                    break;

            }
            menu.showWindow(0);
        }

        private void readProperis(int id_window)
        {
            IFilm film = search_by_id();
            if(film==null) {return;}
            film.read(id_window);
        }
        private void readMethod(int id_window)
        {
            IFilm film = search_by_id();
            if (film == null){return;}
            else if (film is ActionMovie) ((ActionMovie)film).makeRatting(id_window);
            else if (film is Horror) ((Horror)film).countTicketNow(id_window);
            else if (film is Cartoon) ((Cartoon)film).view(id_window);
            else if (film is Comedy) ((Comedy)film).eatPopcorn(id_window);
            Console.ReadLine();
            Console.Clear();
        }
        private IFilm search_by_id()
        {
            Console.WriteLine("Введите id фильма");
            int id;
            string str = Console.ReadLine();
            if (System.Int32.TryParse(str, out id) && id >= 0 && id < films.Count)
            {
                return films[id];
            }
            else
            {
                Console.WriteLine("Не найдено или список пуст(((");
                Console.ReadLine();
                Console.Clear();
                return null;
            }
        }
        
        
        // Отображение всех элементы
        private void getAllListMovie(int id_window)
        {
            if (films.Count == 0)
            {
                Console.WriteLine("Пусто");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            foreach(IFilm film in films)
            {
                film.getName(id_window);
                film.read(id_window);
            }
        }


        private void RandomObjMethod(int id_window)
        {
            var rand = new Random();
            if (films.Count==0) {
                Console.WriteLine("Пусто (нельзя взять пустой объект)");
                Console.ReadLine();
                Console.Clear(); 
                return; 
            }
            IFilm film = films[rand.Next(films.Count)];
            MenuForFilm(film, id_window);
        }
        private void MenuForFilm(IFilm film, int id_window)
        {
            Console.WriteLine("Рандомный объект:");
            if (film == null) { return; }
            film.read(id_window);
        }

   }
}
