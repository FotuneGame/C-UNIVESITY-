using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace ArrauWorkSpace
{
    internal class ArrayWorkerCPP
    {
        private byte[] arr;
        private int size;

        [DllImport(@"Dll_C++.dll", EntryPoint = "print_arr", CallingConvention =CallingConvention.StdCall)]
        public static extern void print_arr(byte[] arr, int arr_length = 36);
        [DllImport(@"Dll_C++.dll", EntryPoint = "write_arr", CallingConvention = CallingConvention.StdCall)]
        public static extern void write_arr(byte[] arr, int arr_length = 36);
        [DllImport(@"Dll_C++.dll", EntryPoint = "delete_equals_symbl", CallingConvention = CallingConvention.StdCall)]
        public static extern void delete_equals_symbl(byte[] arr, int arr_length = 36);

        public ArrayWorkerCPP()
        {
            arr = new byte[36];
            size = 36;
        }

        public ArrayWorkerCPP(int size)
        {
            if (size >= 0)
            {
                arr = new byte[size];
                this.size = size;
            }
        }

        public void Print(int id_window)
        {
            try
            {
                Console.WriteLine("Массив char:");
                if (arr!=null) print_arr(arr, size);
                Console.ReadLine();
                Console.Clear();
            }catch(Exception e) { Console.WriteLine(e); }
        }

        public void Write(int id_window)
        {
            try
            {
                Console.WriteLine("Введите значения:");
                if (arr != null) write_arr(arr, size);
                Console.WriteLine("Достаточно...");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void Work(int id_window)
        {
            try
            {
                Console.WriteLine("Убрали повторяющиеся символы:");
                if (arr != null)
                {
                    delete_equals_symbl(arr, size);
                    print_arr(arr, size);
                }
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

    }
}
