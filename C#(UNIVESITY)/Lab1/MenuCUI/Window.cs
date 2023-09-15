using System;
using System.Collections.Generic;

namespace MenuCUI
{
    internal class Window
    {
        public List<Line> lines;

        public Window() { lines = new List<Line>(); }
        public void ReadButton()
        {
            int index;
            string input = Console.ReadLine();
            if (System.Int32.TryParse(input, out index) && index<lines.Count && index>=0)
            {
                lines[index].Active();
            }
            else
                ReadButton();
        }
    }
}
