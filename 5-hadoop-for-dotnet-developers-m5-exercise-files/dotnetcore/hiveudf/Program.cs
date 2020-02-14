using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string row;
                while ((row = Console.ReadLine()) != null)
                {
                    var fields = row.TrimEnd('\n').Split('\t');
                    var code = fields[0];
                    var description = fields[1].ToUpper();
                    Console.WriteLine($"{code}|{description}");
                }
            }
            catch
            {
                Console.WriteLine("\n");
            }
        }
    }
}
