using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press enter to get your lucky number\n\n");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() => PrintLuckyNumberAsync(token), token);
            task.ContinueWith(t =>
            {
                t.Exception?.Handle(e => true);
                Console.WriteLine("-Stopped-");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Console.ReadLine();
            cancellationTokenSource.Cancel();
            try
            {
                task.Wait();
            }
            catch
            {
            }
        }

        private static void PrintLuckyNumberAsync(CancellationToken cancelToken)
        {
            var rand = new Random();
            int y = -1;
            Console.Write("\b");
            int i = 0;
            while (i++ < 100)
            {
                y = rand.Next(1000, 9999);
                Console.Write(y);
                Thread.Sleep(100);
                Console.Write("\b\b\b\b");
                if (cancelToken.IsCancellationRequested)
                {
                    PrintLuckyNumber(y);
                    cancelToken.ThrowIfCancellationRequested();
                }
            }
            PrintLuckyNumber(y);
        }

        private static void PrintLuckyNumber(int y)
        {
            Console.WriteLine($"\n\nYour lucky number is {y}");
        }
    }
}
