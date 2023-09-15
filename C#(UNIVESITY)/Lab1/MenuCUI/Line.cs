using System;

namespace MenuCUI
{
    internal class Line
    {
        private int window_id;
        public String text;
        public delegate void next(int id);
        public event next Events;

        public Line() { text = "Текст"; }
        public Line(String text, int window_id)
        {
            this.text = text;
            this.window_id = window_id;
        }

        public void Active()
        {
            Console.Clear();
            if (Events!=null) Events(window_id);
        }
    }
}
