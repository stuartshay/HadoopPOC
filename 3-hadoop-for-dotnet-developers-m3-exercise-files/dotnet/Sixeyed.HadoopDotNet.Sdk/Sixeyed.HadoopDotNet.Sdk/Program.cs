using Microsoft.Hadoop.MapReduce;
using System;

namespace Sixeyed.HadoopDotNet.Sdk
{
    class Program
    {
        static void Main(string[] args)
        {
                Environment.SetEnvironmentVariable("HADOOP_HOME", @"C:\Syncfusion\BigData\2.11.0.92\BigDataSDK\\SDK\Hadoop");
                Environment.SetEnvironmentVariable("JAVA_HOME", @"C:\Syncfusion\BigData\2.11.0.92\BigDataSDK\\Java\jdk1.7.0_51");
                           
                var config = new HadoopJobConfiguration();
                config.InputPath = args[0];
                config.OutputFolder = args[1];

                var hadoop = Hadoop.Connect();
                var jobResult = hadoop.MapReduceJob.Execute<AreaClassificationMapper, AreaClassificationReducer>(config);

                
                var exitCode = jobResult.Info.ExitCode;

                string exitStatus = "Failure";

                if (exitCode == 0) exitStatus = "Success";

                exitStatus = exitCode + " (" + exitStatus + ")";

                Console.WriteLine();

                Console.WriteLine($"ExitCode: {exitCode}");
                Console.ReadLine();
        }

    }
}
