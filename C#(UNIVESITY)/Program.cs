using System;


using Menu2Space;
using Menu1Space;

namespace C__UNIVESITY_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите лабораторную работу:");
            Console.WriteLine("1 - 1-ая лабораторная, 2 - 2-ая лабораторная");
            string meny_symb = Console.ReadLine();
            if (meny_symb == "1")
            {
                Menu1 menu = new Menu1();
                Console.WriteLine("Выберите задание:");
                Console.WriteLine("1-задание, 2 - задание, 3 - задание");
                meny_symb = Console.ReadLine();
                switch (meny_symb)
                {
                    case "1": menu.MenuForOneEx(); break;
                    case "2": menu.MenuForTwoEx(); break;
                    case "3": menu.MenuForThreeEx(); break;
                    default: Console.WriteLine("1-задание"); menu.MenuForOneEx(); break;
                }
            }
            else if (meny_symb == "2")
            {
                Menu2 menu2 = new Menu2();
            }
            else Console.WriteLine("Последющие лабы в разработке)");
            
        }
    }
}
