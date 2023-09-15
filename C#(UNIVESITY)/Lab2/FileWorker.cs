using Menu2Space;
using System;
using System.IO;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using MenuCUI;
using System.Security;
using System.Diagnostics;

namespace FileWorkerSpace
{
    static internal class FileWorker
    {
        public static bool HaveFile(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists){return true;}
            try
            {
                File.Create(path).Close();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static  bool ReadTxtFile(string path, LinkedList<Train> trains)
        {
            if (HaveFile(path))
            {
                trains.Clear();
                using (StreamReader stream = new StreamReader(path))
                {
                    Train train;
                    string line = stream.ReadLine();
                    
                    try
                    {
                        while (line != null)
                        {
                            train.number = Convert.ToInt32(line);
                            train.station = stream.ReadLine();
                            train.time_in = Convert.ToDateTime(stream.ReadLine());
                            train.time_out = Convert.ToDateTime(stream.ReadLine());
                            train.HaveTicket = Convert.ToBoolean(stream.ReadLine());
                            line = stream.ReadLine();
                            trains.AddLast(train);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    
                }
                return true;
            }
            return false;
        }
        public static bool WriteTxtFile(string path, LinkedList<Train> trains)
        {
            if (HaveFile(path))
            {
                using (StreamWriter stream = new StreamWriter(path,false))
                {

                    foreach (Train train in trains)
                    {
                        stream.WriteLine(train.number);
                        stream.WriteLine(train.station);
                        stream.WriteLine(train.time_in);
                        stream.WriteLine(train.time_out);
                        stream.WriteLine(train.HaveTicket);
                    }
                }
                return true;
            }
            return false;
        }
        public static bool ReadBINFile(string path, LinkedList<Train> trains)
        {
            if (HaveFile(path))
            {
                trains.Clear();
                using (var stream = File.Open(path, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        Train train;
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            train = new Train();
                            train.number = reader.ReadInt32();
                            train.station = reader.ReadString();
                            train.time_in = DateTime.FromBinary(reader.ReadInt64());
                            train.time_out = DateTime.FromBinary(reader.ReadInt64());
                            train.HaveTicket = reader.ReadBoolean();
                            trains.AddLast(train);
                        }
                       
                    }
                }
                return true;
            }
            return false;
        }
        public static bool WriteBINFile(string path, LinkedList<Train> trains)
        {
            if (HaveFile(path) && trains.Count!=0)
            {
                using (var stream = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    using (var writter = new BinaryWriter(stream, Encoding.UTF8))
                    {
                       foreach(Train train in trains)
                        {
                            writter.Write(train.number);
                            writter.Write(train.station);
                            writter.Write(train.time_in.ToBinary());
                            writter.Write(train.time_out.ToBinary());
                            writter.Write(train.HaveTicket);
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
