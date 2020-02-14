using System;

namespace Sixeyed.HadoopDotNet.Reducer
{
    class Program
    {
        static void Main(string[] args)
        {
            string classification = null;
            var count = 0L;

            var line = Console.ReadLine();
            while (line != null)
            {
                var parts = line.Split('\t');
                var key = parts[0];
                var value = long.Parse(parts[1]);

                if (key == classification)
                {                    
                    count += value;
                }
                else
                {
                    if (classification != null)
                    {
                        Console.WriteLine($"{classification}\t{count}");
                    }
                    classification = key;
                    count = value;
                }

                line = Console.ReadLine();
            }
            Console.WriteLine($"{classification}\t{count}");
        }
    }
}
