using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pbar
{
    public static class ProgressBar
    {
        private static object obj = new object();
        private static CancellationTokenSource cts;
        private static Task tsk;


        private static int currentCursor = 0;
        private static int currentCursordynamic = 0;
        private static int index = 0;


        public static void StartProgressBar()
        {
            cts = new CancellationTokenSource();
            tsk = Task.Factory.StartNew(Progress, cts.Token, cts.Token);
        }
        public static void EndProgressBar()
        {
            cts.Cancel();
            tsk.Wait();
            Console.CursorTop = index++;
            currentCursordynamic = currentCursor = index = 0;

        }
        private static void Progress(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            currentCursordynamic = currentCursor = Console.CursorTop;
            index = currentCursordynamic + 1;
            while (!ct.IsCancellationRequested)
            {
                for (int i = 0; i < 15; i++)
                {
                    lock (obj)
                    {
                        Console.SetCursorPosition(i, currentCursor);
                        Console.Write("- ");
                        Thread.Sleep(200);
                    }
                }

                ClearCurrentConsoleLine();
            }
            ClearCurrentConsoleLine();
        }
        public static void Print(string fileName, string line, string type)
        {
            lock (obj)
            {
                Console.SetCursorPosition(0, index);
                Console.WriteLine("FileName = {0}, Line = {1}, type = {2}", fileName, line, type);
                currentCursor = currentCursordynamic;
                index++;
            }
        }
        public static void Print(string str)
        {
            lock (obj)
            {
                Console.SetCursorPosition(0, index);
                Console.WriteLine(str);
                currentCursor = currentCursordynamic;
                index++;
            }
        }
        public static void Print(string fileName, Exception ex)
        {
            lock (obj)
            {
                Console.SetCursorPosition(0, index);
                Console.WriteLine("FileName = {0}, Exeeption Massage = {1}", fileName, ex.Message);
                currentCursor = currentCursordynamic;
                index++;
            }
        }
        private static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, currentCursor);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentCursor);
        }
    }
}
