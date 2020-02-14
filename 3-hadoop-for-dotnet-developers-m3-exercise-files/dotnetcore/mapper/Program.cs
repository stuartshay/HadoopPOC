using CsvHelper;
using System;
using System.IO;

namespace Sixeyed.HadoopDotNetCore.Mapper
{
    public class Program
    {
        private static int CLASSIFICATION_FIELD_INDEX = 29;

        public static void Main(string[] args)
        {
            var line = Console.ReadLine();
            while (line != null)
            {
                using (var reader = new StringReader(line))
                using (var parser = new CsvParser(reader))
                {
                    var fields = parser.Read();
                    if (fields.Length >= CLASSIFICATION_FIELD_INDEX)
                    {
                        Console.WriteLine($"{fields[CLASSIFICATION_FIELD_INDEX]}\t1");
                    }
                }
                line = Console.ReadLine();
            }
        }     
    }
}