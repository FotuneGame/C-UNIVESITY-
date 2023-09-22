using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuCUI;
using FileWorkerSpace;
using System.Threading;
using System.IO;

namespace Menu3Space
{
    internal class Menu3
    {
        string[] path;
        Menu menu;

        public Menu3() { start(); CUI_Setting();}
        void start()
        {
            menu = new Menu(); path = new string[2] { null , null };
        }
        void OpenTwoFile(int id_window)
        {
            Console.Clear();
            string[] path_new= {null,null};
            do
            {
                Console.WriteLine("Путь до текстового файла 1:");
                path_new[0] = Console.ReadLine();
                Console.WriteLine("Путь до текстового файла 2:");
                path_new[1] = Console.ReadLine();
            } while (path_new[0] == "" || path_new[1] == "");
            FileInfo[] fileInf = { new FileInfo(path_new[0]), new FileInfo(path_new[1]) };
            if (!fileInf[0].Exists || !fileInf[1].Exists)
            {
                Console.WriteLine("Одного файла или обоих таких файлов нет!");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            Console.Clear();
            path[0] = path_new[0]; path[1] = path_new[1];
        }

        void getCountWordInFiles(int id_window)
        {
            if (path[0] != null && path[0] != null)
            {
                FileWorkerWithCPP file = new FileWorkerWithCPP(path[0], true);
                Console.WriteLine("Слов в файле: " + path[0] + " :" + file.getLenght());
                file = new FileWorkerWithCPP(path[1], true);
                Console.WriteLine("Слов в файле: " + path[1] + " :" + file.getLenght());
                Console.ReadLine();
                Console.Clear();
            }
        }

        // сделать множества из слов в файлах
        void setPlenty(int id_window)
        {
            if (path[0] != null && path[0] != null)
            {
                FileWorkerWithCPP file_1 = new FileWorkerWithCPP(path[0], true);
                FileWorkerWithCPP file_2 = new FileWorkerWithCPP(path[1], true);
                List<string> str_list_1 = new List<string>();
                List<string> str_list_2 = new List<string>();
                StringBuilder word_file = new StringBuilder(255);
                for (int i = 1; i <= file_1.getLenght() && file_1.readWord(i, word_file); i++) str_list_1.Add(word_file.ToString());
                for (int i = 1; i <= file_2.getLenght() && file_2.readWord(i, word_file); i++)
                {
                    if (!str_list_1.Contains(word_file.ToString()))
                        str_list_2.Add(word_file.ToString());
                }
                for (int i = 1; i <= file_2.getLenght() && file_2.readWord(i, word_file); i++)
                {
                    if (str_list_1.Contains(word_file.ToString()))
                        str_list_1.RemoveAll(x=> x.ToString()== word_file.ToString());
                }
                string res_1 = "", res_2="";
                foreach (string str in str_list_1) res_1 += str + "\n";
                foreach (string str in str_list_2) res_2 += str + "\n";

                FileWorkerWithCPP file_writer_1 = new FileWorkerWithCPP(path[0], false);
                FileWorkerWithCPP file_writer_2 = new FileWorkerWithCPP(path[1], false);
                // тоже тут хз почему работает с двумя вызовами нормально??
                file_writer_1.writeAllWord(res_1);
                file_writer_1.writeAllWord(res_1);
                file_writer_2.writeAllWord(res_2);
                file_writer_2.writeAllWord(res_2);

                Console.WriteLine("Файлы теперь с уникальными словами ) ");
                Console.ReadLine();
                Console.Clear();
            }
        }

        void sortWordBySymbolInFiles(int id_window)
        {
            if (path[0] != null && path[0] != null)
            {
                int i;
                string str_result;
                for (int step_file = 0; step_file < 2; step_file++)
                {
                    str_result = "";
                    FileWorkerWithCPP file = new FileWorkerWithCPP(path[step_file], true);
                    List<string> str_list = new List<string>();
                    StringBuilder word_file_1 = new StringBuilder(255);
                    for (i = 1; i <= file.getLenght() && file.readWord(i, word_file_1); i++)
                    {
                        str_list.Add(word_file_1.ToString());
                    }
                    
                    FileWorkerWithCPP file_writer = new FileWorkerWithCPP(path[step_file], false);
                    str_list.Sort((x, y) => x.Length.CompareTo(y.Length));
                    foreach (string str in str_list)
                    {
                        str_result += str + "\n";
                    }
                    
                    Console.WriteLine(str_result);
                    // я хз почему работает только если 2 раза записать в файл
                    file_writer.writeAllWord(str_result);
                    file_writer.writeAllWord(str_result);
                    Console.WriteLine("Файл отсортирован) Слов всего: " + i + " Файл: " + path[step_file]);
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
        void CUI_Setting()
        {
            Window main = new Window();

            Line main_line_1 = new Line("Открыть файлы", 0);
            Line main_line_2 = new Line("Получить количество слов в файлах", 0);
            Line main_line_3 = new Line("Оставить в первом файле только слова, отсутствующие во втором, а во втором – отсутствующие в первом.", 0);
            Line main_line_4 = new Line("Отсортировать слова в файлах по количеству букв", 0);
            Line main_line_5 = new Line("Выход", -1);
            main.lines.Add(main_line_1);
            main.lines.Add(main_line_2);
            main.lines.Add(main_line_3);
            main.lines.Add(main_line_4);
            main.lines.Add(main_line_5);

            main_line_1.Events += OpenTwoFile;
            main_line_2.Events += getCountWordInFiles;
            main_line_3.Events += setPlenty;
            main_line_4.Events += sortWordBySymbolInFiles;

            Console.Clear();
            menu.windows.Add(main);
            menu.showWindow(0);
        }
    }
}
