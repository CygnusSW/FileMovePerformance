using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoveFilePerformanceMarker
{
    class Program
    {
        private const int TIMES_TO_RUN = 500;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            int counter = 0;
            double totalMS = 0;
            var originalFilename = $@"C:\users\cory.johnson\Desktop\performance_0.csv";
            long totalBytes = new FileInfo(originalFilename).Length;
            var timesToCopy = 500;
            while (true)
            {
                var srcFilename = $@"C:\users\cory.johnson\Desktop\performance_{counter.ToString()}.csv";
                var destFilename = $@"C:\users\cory.johnson\Desktop\performance_{ (counter + 1).ToString()}.csv";

                var stopwatch = new Stopwatch();
                stopwatch.Start();
                
                File.Move(srcFilename, destFilename);
                stopwatch.Stop();
                Console.WriteLine($"Counter: {counter}; Elapsed: {stopwatch.Elapsed.TotalMilliseconds}");
                totalMS += stopwatch.Elapsed.TotalMilliseconds;
                counter++;

                if (counter == timesToCopy)
                {
                    File.Move(destFilename, originalFilename);
                    break;
                }
            }



            Console.WriteLine($"Completed Moved {totalBytes/1024/1024 * timesToCopy} MB {timesToCopy} times in: {totalMS / 1000 } seconds");
            Console.ReadLine();




        }
    }
}
