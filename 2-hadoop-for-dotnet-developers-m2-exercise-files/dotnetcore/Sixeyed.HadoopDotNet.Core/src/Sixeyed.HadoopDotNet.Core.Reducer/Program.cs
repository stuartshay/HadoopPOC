using System;

namespace Sixeyed.HadoopDotNet.Core.Reducer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string classification = null;
            var count = 0;

            var line = Console.ReadLine();
            while (line != null)
            {
                if (line == classification)
                {
                    count++;
                }
                else 
                {
                    if (classification != null)
                    {
                        Console.WriteLine($"{classification}\t{count}");
                    }
                    classification = line;
                    count = 1;
                }
                line = Console.ReadLine();
            }
            Console.WriteLine($"{classification}\t{count}");
        }
    }
}
