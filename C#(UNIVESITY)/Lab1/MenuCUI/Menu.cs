using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuCUI
{
    internal class Menu : IMenu
    {
        public List<Window> windows;

        public Menu() { windows = new List<Window>(); }
        public void showWindow(int id)
        {

            if (windows.Count != 0 &&  id >= 0 && id < windows.Count)
            {
                int i = 0;
                foreach (Line line in windows[id].lines)
                {
                    line.Events += showWindow;
                    Console.WriteLine(i + ") " + line.text);
                    i++;
                }
                windows[id].ReadButton();
            }else if (id < 0)
            {
                System.Environment.Exit(0); //закрытие приложения
            }
        }

    }
}
