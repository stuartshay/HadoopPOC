## Hadoop for .NET Developers - Module 3

### Microsoft Hadoop SDK for .NET

A simple example of a MapReduce job written with the Hadoop SDK, which can run as a Hadoop job on Windows platforms.

The console project is in a Visual Studio 2015 solution.

To run the app as a MapReduce job in Hadoop, you just need to build and run the console app, passing the HDFS input and output paths as arguments:

```
Sixeyed.HadoopDotNetSdk.exe \
-input /input/* \
-output /output-dotnetsdk
```

**Note** the paths for Hadoop and Java are set in the Program.cs file for Syncfusion's Big Data Platform - you will need to ensure the paths are correct for your environment.