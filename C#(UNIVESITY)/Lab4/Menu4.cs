
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MenuCUI;
using ArrauWorkSpace;

namespace Menu4Space
{
    internal class Menu4
    {
        ArrayWorkerCPP arr;
        Menu menu;

        public Menu4() { start(); CUI_Setting(); }
        void start()
        {
            menu = new Menu();
            arr = new ArrayWorkerCPP(5);
        }
        void CUI_Setting()
        {
            Window main = new Window();

            Line main_line_1 = new Line("Вывод массива", 0);
            Line main_line_2 = new Line("Заполнение массива", 0);
            Line main_line_3 = new Line("Заменить повторяющиеся символы на пробелы (за исключением символа «пробел»).", 0);
            Line main_line_4 = new Line("Выход", -1);
            main.lines.Add(main_line_1);
            main.lines.Add(main_line_2);
            main.lines.Add(main_line_3);
            main.lines.Add(main_line_4);

            main_line_1.Events += arr.Print;
            main_line_2.Events += arr.Write;
            main_line_3.Events += arr.Work;

            Console.Clear();
            menu.windows.Add(main);
            menu.showWindow(0);
        }
    }
}
