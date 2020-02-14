using CsvHelper;
using System;
using System.IO;

namespace Sixeyed.HadoopDotNetCore.Mapper
{
    public class Program
    {
        private static int CLASSIFICATION_CODE_INDEX = 28;
        private static int CLASSIFICATION_FIELD_INDEX = 29;

        public static void Main(string[] args)
        {
            var line = Console.ReadLine();
            while (line != null)
            {
                using (var reader = new StringReader(line))
                using (var parser = new CsvParser(reader))
                {
                    try 
                    {
                        var fields = parser.Read();
                        if (fields.Length >= CLASSIFICATION_CODE_INDEX)
                        {
                            Console.WriteLine($"{fields[CLASSIFICATION_CODE_INDEX]}\t1");
                        }
                    }
                    catch
                    {
                        Console.Error.WriteLine("reporter:counter:Area Classification,Bad input lines,1");
                    }
                }
                line = Console.ReadLine();
            }
        }     
    }
}