using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogManager
{
    public static class LogConsole
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
            tsk = Task.Factory.StartNew(ProgressBar, cts.Token, cts.Token);
        }
        public static void EndProgressBar()
        {
            cts.Cancel();
            tsk.Wait();
            Console.Beep();
            Console.CursorTop = index++;
            currentCursordynamic = currentCursor = index = 0;

        }
        public static void ProgressBar(object obj)
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
        public static void Tpel(string a)
        {
            lock (obj)
            {
                Console.SetCursorPosition(0, index);
                Console.WriteLine(a);
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
