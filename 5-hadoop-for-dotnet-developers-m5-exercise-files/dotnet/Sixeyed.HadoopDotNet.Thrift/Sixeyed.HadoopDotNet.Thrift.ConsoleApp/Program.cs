using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Transport;
using Thrift.Protocol;

namespace Sixeyed.HadoopDotNet.Thrift.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new TSocket("127.0.0.1", 10003);
            var transport = new TBufferedTransport(socket);
            var protocol = new TBinaryProtocol(transport, true, true);
            var client = new Hbase.Client(protocol);
            transport.Open();

            var postcode = Console.ReadLine();
            while (postcode != null)
            {
                var cells = client.get(ToBytes("PostcodesRealtime"), ToBytes(postcode), ToBytes("ac:description"), null);
                Console.WriteLine(FromBytes(cells.First().Value));
                postcode = Console.ReadLine();
            }
        }

        private static byte[] ToBytes(string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        private static string FromBytes(byte[] input)
        {
            return Encoding.UTF8.GetString(input);
        }
    }
}
