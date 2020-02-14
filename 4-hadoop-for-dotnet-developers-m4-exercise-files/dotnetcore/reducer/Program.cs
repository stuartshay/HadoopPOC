using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Sixeyed.HadoopDotNetCore.Reducer
{
    public class Program
    {
        private static Dictionary<string, string> _CodeLookup = new Dictionary<string, string>();

        static Program()
        {
            var lines = File.ReadAllLines("refdata\\area-codes.csv");
            foreach (var line in lines.Where(x => x.Length > 0))
            {
                var code = line.Substring(0,3).ToUpper();
                var description = line.Substring(4);
                _CodeLookup[code] = description;
            }
        }

        public static void Main(string[] args)
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
                        EmitClassification(classification, count);
                    }
                    classification = key;
                    count = value;
                }

                line = Console.ReadLine();
            }
            EmitClassification(classification, count);
        }

        private static void EmitClassification(string code, long count)
        {
            if (_CodeLookup.ContainsKey(code))
            {
                //Thread.Sleep(1000);
                Console.WriteLine($"{_CodeLookup[code]}\t{count}");
            }
            else
            {
                Console.Error.WriteLine("reporter:counter:Area Classification,Unknown code,1");
                Console.Error.WriteLine($"Reducer ignored unknown code: {code}, with count: {count}");
            }
        }
    }
}