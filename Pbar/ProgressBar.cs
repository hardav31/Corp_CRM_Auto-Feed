using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pbar
{
    public static class ProgressBar
    {
        private static object obj = new object();
        private static CancellationTokenSource cts;
        private static Task tsk;

        private static readonly int length = 15;
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
        }
        private static void Progress(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            currentCursordynamic = currentCursor = Console.CursorTop;
            index = currentCursordynamic + 1;
            while (!ct.IsCancellationRequested)
            {
                for (int i = 0; i < length; i++)
                {
                    if (ct.IsCancellationRequested) { break; }
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
        public static void Print(string info, string message, string type)
        {
            lock (obj)
            {
                int x = info.Length + message.Length + type.Length;
                x = x / Console.WindowWidth+1;
                Console.SetCursorPosition(0, index + x);
                Console.WriteLine("{0},  {1},  {2}", info, message, type);
                currentCursor = currentCursordynamic;
                index = index + x;
            }
        }
        public static void Print(string str)
        {
            lock (obj)
            {
                int x = str.Length;
                x = x / Console.WindowWidth+1;
                Console.SetCursorPosition(0, index + x);
                Console.WriteLine(str);
                currentCursor = currentCursordynamic;
                index = index + x;
            }
        }
        public static void Print(string info, Exception ex)
        {
            lock (obj)
            {
                int x = info.Length + ex.Message.Length;
                x = x / Console.WindowWidth+1;

                Console.SetCursorPosition(0, index + x);
                Console.WriteLine("{0},  {1}", info, ex.Message);
                currentCursor = currentCursordynamic;
                index = index + x;
            }
        }
        private static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, currentCursor);
            Console.Write(new string(' ', length));
            Console.SetCursorPosition(0, currentCursor);
        }
    }
}
