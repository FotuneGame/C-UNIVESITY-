using System;
using System.Collections.Generic;
using System.Linq;


using FileWorkerSpace;
using MenuCUI;

namespace Menu2Space
{
    struct Train
    {
        public int number;
        public string station;
        public DateTime time_out;
        public DateTime time_in;
        public bool HaveTicket;
    }
    internal class Menu2
    {
        Menu menu;

        private bool isBinFile;
        public string file;
        LinkedList<Train> trains;

        public Menu2() { trains = new LinkedList<Train>(); menu = new Menu(); start(); CUI_Setting(); }

        private int search_by_id()
        {
            int id;
            Console.WriteLine("Введите id поезда из коллекции:");
            string str = Console.ReadLine();
            if (System.Int32.TryParse(str, out id) && id >= 0 && id < trains.Count)
            {
                return id;
            }
            else
            {
                Console.WriteLine("Нет такого поезда с id...");
                Console.ReadLine();
                Console.Clear();
                return -1;
            }
        }
        private bool AddTrainMenu(ref Train train)
        {
            try
            {
                Console.WriteLine("Номер поезда");
                train.number=System.Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Станция прибытия");
                train.station = Console.ReadLine();
                Console.WriteLine("Время отбытия");
                train.time_in = System.Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Время в пути");
                train.time_out = System.Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Наличие билетов");
                train.HaveTicket = System.Convert.ToBoolean(Console.ReadLine());
                Console.Clear();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Неверное заполнение" + ex);
                Console.ReadLine();
                Console.Clear();
            }
            return false;
        }
        private void addTrainLeft(int id_window)
        {
            Train train = new Train();
            if(AddTrainMenu(ref train))
                trains.AddFirst(train);
        }
        private void addTrainRight(int id_window)
        {
            Train train = new Train();
            if (AddTrainMenu(ref train))
                trains.AddLast(train);
        }
        private void addTrainMiddle(int id_window)
        {
            int id = search_by_id();
            if (id != -1)
            {
                int i = 0;
                for (LinkedListNode<Train> node_train = trains.First; node_train != null; node_train = node_train.Next, i++)
                {
                    if (i == id)
                    {
                        Train train = new Train();
                        if (AddTrainMenu(ref train))
                            trains.AddAfter(node_train, train);
                        break;
                    }
                }
            }
        }
        private void deleteTrainId(int id_window) {
            int id = search_by_id();
            if (id != -1)
            {
                Console.WriteLine("Вы точно хотите УДАЛИТЬ запис про поезд (1 - удалить, все остальное - оставить):");
                int i = 0;
                LinkedListNode<Train> node_train;
                for (node_train = trains.First; node_train != null; node_train = node_train.Next, i++)
                {
                    if (i == id)
                    {
                        showTrain(node_train.Value);
                        break;
                    }
                }
                if (Console.Read() == '1') trains.Remove(node_train);
                Console.Clear();
                
            }
        }
        private void updateTrain(int id_window)
        {
            int id = search_by_id();
            if (id != -1)
            {
                Console.WriteLine("Вы точно хотите Обновить запис про поезд (1 - перезаписать, все остальное - оставить):");
                int i = 0;
                LinkedListNode<Train> node_train;
                for (node_train = trains.First; node_train != null; node_train = node_train.Next, i++)
                {
                    if (i == id)
                    {
                        showTrain(node_train.Value);
                        break;
                    }
                }
                if (Console.ReadLine() == "1")
                {
                    Train train = new Train();
                    if (AddTrainMenu(ref train))
                        node_train.Value = train;
                }
                else Console.Clear();
            }
        }
        private void sort_by_station(int id_window)
        {
            // не самое лучшее решение как по мне, но быстро для написания) 
            var new_trains = trains.OrderBy(train => train.station.Length).ThenBy(train => train.station).ToList();
            if (new_trains.Count != 0)
            {
                Console.WriteLine("|_Номер_|__Станция направления__|__Время отправления__|____Время в пути_____|__Билеты__|");
                foreach (Train train in new_trains)
                {
                    showTrain(train);
                }
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Поездов нет");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void sort_by_station_and_time_interval(int id_window)
        {
            try
            {
                Console.WriteLine("Введите время от:");
                DateTime time_start = System.Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Введите время до:");
                DateTime tine_finish = System.Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Пункт прибытия:");
                string name = Console.ReadLine();

                if (trains.Count != 0)
                {
                    Console.WriteLine("|_Номер_|__Станция направления__|__Время отправления__|____Время в пути_____|__Билеты__|");
                    foreach (Train train in trains)
                    {
                        if(train.station == name && time_start <= train.time_in && train.time_in <= tine_finish)
                            showTrain(train);
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Поездов нет");
                    Console.ReadLine();
                    Console.Clear();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Неверное заполнение" + ex);
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void check_ticket(int id_window) 
        {
            try
            {
                Console.WriteLine("Введите номер поезда:");
                int number = System.Convert.ToInt32(Console.ReadLine());
                bool haveTrain = false;
                foreach(Train train in trains)
                {
                    if (train.number == number)
                    {
                        if (train.HaveTicket) Console.WriteLine("Билеты есть");
                        else Console.WriteLine("Билеты нет");
                        haveTrain = true;
                        break;
                    }
                }
                if(!haveTrain) Console.WriteLine("Поезда с таким номер нет!");
                Console.ReadLine();
                Console.Clear();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Неверное заполнение" + ex);
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void showTrain(Train train)
        {
            string number = train.number.ToString();
            Console.Write("|" + number.PadRight(7, '_').Substring(0, 7));

            string station = train.station.ToString();
            Console.Write("|" + station.PadRight(23, '_').Substring(0, 23));

            string time_out = train.time_out.ToString();
            Console.Write("|" + time_out.PadRight(21, '_').Substring(0, 21));

            string time_in = train.time_in.ToString();
            Console.Write("|" + time_in.PadRight(21, '_').Substring(0, 21));

            string HaveTicket = train.HaveTicket.ToString();
            Console.Write("|" + HaveTicket.PadRight(10, '_').Substring(0, 10) + "|" + '\n');
        }
        private void showAllTrain(int id_window)
        {
            if (trains.Count != 0)
            {
                Console.WriteLine("|_Номер_|__Станция направления__|__Время отправления__|____Время в пути_____|__Билеты__|");
                foreach (Train train in trains)
                {
                    showTrain(train);
                }
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Поездов нет");
                Console.ReadLine();
                Console.Clear();
            }

        }
        
        
        private void saveToFile(int id_window)
        {
            if (isBinFile && FileWorker.WriteBINFile(file, trains))
            {
                    Console.WriteLine("Сохранено в бинарный файл");
                    Console.ReadLine();
                    Console.Clear();
            }
            else if(!isBinFile && FileWorker.WriteTxtFile(file, trains))
            {
                Console.WriteLine("Сохранено в текстовый файл");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Не удалось сохранить");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void start()
        {
            string s;
            do
            {
                Console.WriteLine("0 - бинарный файл, 1 - текстовый файл");
                s = Console.ReadLine();
            } while (s != "1" && s != "0");
            switch (s)
            {
                case "1": isBinFile = false; break;
                case "0": isBinFile = true; break;
            }
            
            Console.WriteLine("Введите имя файла");
            file= Console.ReadLine();
            if (!FileWorker.HaveFile(file)) Console.Write("Ошибка (файл не создан)");

            trains=new LinkedList<Train>();


            
            if (isBinFile)
            {
                //FileWorker.WriteBINFile(file, trains);
                FileWorker.ReadBINFile(file, trains);
            }
            else
            {
                // FileWorker.WriteTxtFile(file, trains);
                FileWorker.ReadTxtFile(file, trains);
            }
           
        }
        public void CUI_Setting()
        {
            Window main = new Window();

            Line main_line_1 = new Line("Просмотреть всё",0);
            Line main_line_2 = new Line("Добавить", 1);
            Line main_line_3 = new Line("Удалить по id", 0);
            Line main_line_3_1 = new Line("Редактировать по id", 0);
            Line main_line_4 = new Line("Сортировка коллекции (по станциям в алфавитном порядка)",0);
            Line main_line_5 = new Line("Вывод поезда по городу и во временном интервале",0);
            Line main_line_6 = new Line("Инфа про билеты на поезд с номером...",0);
            Line main_line_7 = new Line("Сохранить в файл", 0);
            Line main_line_8 = new Line("Выход", -1);
            main.lines.Add(main_line_1);
            main.lines.Add(main_line_2);
            main.lines.Add(main_line_3);
            main.lines.Add(main_line_3_1);
            main.lines.Add(main_line_4);
            main.lines.Add(main_line_5);
            main.lines.Add(main_line_6);
            main.lines.Add(main_line_7);
            main.lines.Add(main_line_8);


            main_line_1.Events += showAllTrain;
            main_line_3.Events += deleteTrainId;
            main_line_3_1.Events += updateTrain;
            main_line_4.Events += sort_by_station;
            main_line_5.Events += sort_by_station_and_time_interval;
            main_line_6.Events += check_ticket;
            main_line_7.Events += saveToFile;


            Window add = new Window();

            Line add_line_1 = new Line("В начало", 1);
            Line add_line_2 = new Line("В конец", 1);
            Line add_line_3 = new Line("В любое место после id",1);
            Line add_line_4 = new Line("Назад", 0);
            add.lines.Add(add_line_1);
            add.lines.Add(add_line_2);
            add.lines.Add(add_line_3);
            add.lines.Add(add_line_4);

            add_line_1.Events += addTrainLeft;
            add_line_2.Events += addTrainRight;
            add_line_3.Events += addTrainMiddle;

            Console.Clear();
            menu.windows.Add(main);
            menu.windows.Add(add);
            menu.showWindow(0);
        }
    }
}
