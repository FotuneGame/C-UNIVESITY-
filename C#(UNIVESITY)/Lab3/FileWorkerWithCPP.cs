using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileWorkerSpace
{
    internal class FileWorkerWithCPP
    {
        private IntPtr file;

        [DllImport("file32.dll")]
        public static extern IntPtr open(string path, bool read);
        [DllImport("file32.dll")]
        public static extern void close(IntPtr file);
        [DllImport("file32.dll")]
        public static extern bool read(IntPtr file, int num, StringBuilder word);
        [DllImport("file32.dll")]
        public static extern void write(IntPtr file, string text);
        [DllImport("file32.dll")]
        public static extern int length(IntPtr file);

        public FileWorkerWithCPP(){
            try
            {
                file = open("18.txt", true);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public FileWorkerWithCPP(string  path, bool read) {
            try
            {
                file = open(path, read);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        ~FileWorkerWithCPP() {
            try
            {
                if (file != IntPtr.Zero) close(file);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public int getLenght() 
        {
            try
            {
                if (file != IntPtr.Zero) return length(file);
                else return -1;
            }catch(Exception ex) { return -1; }
        }

        public bool readWord(int id, StringBuilder word)
        {
            try
            {
                if (file != IntPtr.Zero) return read(file, id, word);
                else return false;
            }catch(Exception ex) { return false; }
        }
        public void writeAllWord(string text) {
            try
            {
                if (file != IntPtr.Zero) write(file, text);
            }catch(Exception ex) { Console.WriteLine(ex); }
        }
    }
}
