using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GarbageCollectorInCSharp
{
    class GCProgram
    {
        private const long maxGarbage = 1000;
        public void Start()
        {
            // GC - КЛАСС УПРАВЛЕНИЯ СБОРЩИКОМ МУСОРА 
            GCProgram myGCCol = new GCProgram();
            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);
            myGCCol.MakeSomeGarbage();
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));// получения поколения объекта
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));//получить размер занимаемой памяти не дожидаясь сборщика мусора
            GC.Collect(0);
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            GC.Collect(2);
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            Console.Read();
        }
        void MakeSomeGarbage()
        {
            // не наследуемый класс дающий инфу про сборку
            Version vt;
            StringBuilder s;
            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
                s = new StringBuilder();
            }
        }
    }
}
