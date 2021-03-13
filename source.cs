using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace ComboChecker
{
    // Token: 0x02000002 RID: 2
    internal class Program
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002098 File Offset: 0x00000298
        private static void Main(string[] args)
        {
            Program.collection.Add(Program.patter8);
            Program.collection.Add(Program.patterCapital);
            Console.Title = "Combo Filter | V-DEVS";
            Thread.Sleep(3000);
            Console.WriteLine("\n ");
            Thread.Sleep(1000);
            Console.WriteLine("nah damn it");
            Console.WriteLine("\n ");
            Console.Write("COMBO FILTER 1.0 !!!", Color.IndianRed);
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Loaded {0}", Program.combo.Count, Color.Red);
            Console.WriteLine("\r\nSelect Module:\r\n\r\n\r\n [1] Password of a length of 8\r\n [2] Password [1] and start with Capital\r\n [3] Password custom length\r\n [4] Custom(Regex)\r\n\r\n", Color.GreenYellow);
            Program.select(Convert.ToInt32(Console.ReadLine()));
        }

        // Token: 0x06000003 RID: 3 RVA: 0x0000217C File Offset: 0x0000037C
        private static void check(int x)
        {
            File.Delete("valid.txt");
            using (StreamWriter streamWriter = File.AppendText("valid.txt"))
            {
                streamWriter.Flush();
                foreach (string text in Program.combo)
                {
                    string[] array = text.ToString().Split(new char[]
                    {
                        ':'
                    });
                    if (Program.collection[x].IsMatch(array[1]))
                    {
                        Console.WriteLine("Correct Combo found: {0}:{1}", array[0], array[1], Color.GreenYellow);
                        streamWriter.WriteLine(array[0] + ":" + array[1]);
                        Program.count++;
                    }
                }
            }
            Console.WriteLine("\n\nFound {0} out of {1} matching Combos", Program.count, Program.combo.Count, Color.LightGreen);
            Console.WriteLine("Press any key to close..", Color.LightGreen);
            Console.Read();
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000022A8 File Offset: 0x000004A8
        private static void select(int x)
        {
            Console.Clear();
            switch (x)
            {
            case 1:
                Program.check(0);
                return;
            case 2:
                Program.check(1);
                return;
            case 3:
            {
                Console.WriteLine("Enter Length of Password", Color.Aqua);
                Regex item = new Regex("^(?=.*[A-Z]).{" + Convert.ToInt32(Console.ReadLine()).ToString() + ",}$");
                Program.collection.Add(item);
                Program.check(2);
                return;
            }
            case 4:
            {
                Console.WriteLine("Enter you regex (Example: ^(?=.*[A-Z]).{8,}$)", Color.Aqua);
                Regex item2 = new Regex(Console.ReadLine().ToString() ?? "");
                Program.collection.Add(item2);
                Program.check(2);
                return;
            }
            default:
                return;
            }
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002057 File Offset: 0x00000257
        public Program()
        {
        }

        // Token: 0x06000006 RID: 6 RVA: 0x0000236C File Offset: 0x0000056C
        static Program()
        {
        }

        // Token: 0x04000001 RID: 1
        private static Regex patter8 = new Regex("^(?=.*[A-Z]).{8,}$");

        // Token: 0x04000002 RID: 2
        private static Regex patterCapital = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\\d]).{8,}$");

        // Token: 0x04000003 RID: 3
        private static int count;

        // Token: 0x04000004 RID: 4
        private static List<Regex> collection = new List<Regex>();

        // Token: 0x04000005 RID: 5
        private static List<Thread> threads = new List<Thread>();

        // Token: 0x04000006 RID: 6
        private static List<string> combo = new List<string>(File.ReadAllLines("combo.txt"));
    }
}
