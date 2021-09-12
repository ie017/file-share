using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Generating numbers b/w 1 to 100...\nPress enter to find you number your lucky number\n\n");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() => GetLuckyNumberAsync(token), token);
            //task.ContinueWith(t =>
            //{
            //    t.Exception?.Handle(e => true);
            //}, TaskContinuationOptions.OnlyOnCanceled);

            Console.ReadLine();
            cancellationTokenSource.Cancel();
            task.Wait();
        }

        private static void PrintLuckyNumber(int y)
        {
            Console.WriteLine($"\n\nYour lucky number is {y}");
        }

        private static void GetLuckyNumberAsync(CancellationToken cancelToken)
        {
            var rand = new Random();
            int y = -1;
            Console.Write("\b");
            int i = 0;
            while (i++ < 10)
            {
                y = rand.Next(1, 100);
                Console.Write(y);
                Thread.Sleep(100);
                Console.Write("\b");
                if (y > 9) Console.Write("\b");
                if (cancelToken.IsCancellationRequested)
                {
                    PrintLuckyNumber(y);
                    return;
                    //cancelToken.ThrowIfCancellationRequested();
                }
            }
            PrintLuckyNumber(y);
        }
    }
}
