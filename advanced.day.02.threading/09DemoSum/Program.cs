namespace _09DemoSum
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Numerics;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var arraySize = 50000000; // 50 000 000
            var array = BuildAnArray(arraySize);

            var count = Environment.ProcessorCount;

            Console.WriteLine($"nr of proc: {count}");

            List<ArrayProcessor> processors = new List<ArrayProcessor>(count);

            List<Thread> threads = new List<Thread>();

            int batchSize = arraySize / count;

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < count; i++)
            {
                var ap = new ArrayProcessor(array, i * batchSize, batchSize);

                processors.Add(ap);

                var t = new Thread(ap.CalculateSum);

                threads.Add(t);
                
                t.Start();
            }

            BigInteger totalSum = 0;
            for (int i = 0; i < count; i++)
            {
                threads[i].Join();

                totalSum += processors[i].Sum;
            }

            //var arrayProcessor = new ArrayProcessor(array, 0, arraySize);

            //arrayProcessor.CalculateSum();
            //var totalSum = arrayProcessor.Sum;

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine($"Sum: {totalSum}");
        }

        public static int[] BuildAnArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
