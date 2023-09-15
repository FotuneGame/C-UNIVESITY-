using System;


using Menu2Space;
using Menu1Space;

namespace C__UNIVESITY_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Menu1 menu = new Menu1();
            Console.WriteLine("1-задание, 2 - задание, 3 - задание");
            string meny_symb=Console.ReadLine();
            switch (meny_symb) {
                case "1": menu.MenuForOneEx(); break;
                case "2": menu.MenuForTwoEx(); break;
                case "3": menu.MenuForThreeEx(); break;
                default: Console.WriteLine("1-задание"); menu.MenuForOneEx(); break;
            }*/
            Menu2 menu = new Menu2();
        }
    }
}
