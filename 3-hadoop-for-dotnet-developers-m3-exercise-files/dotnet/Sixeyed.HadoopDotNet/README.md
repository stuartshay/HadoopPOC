## Hadoop for .NET Developers - Module 3

### .NET Framework MapReduce code

A simple example of a mapper and reducer written as .NET console apps, which can run as a Hadoop job on Windows platforms.

The console projects are in a Visual Studio 2015 solution.

To run the apps as a MapReduce job in Hadoop, firstly build the solution, and copy the output files to a directory, e.g. `c:\dotnet`.

Then submit the streaming job - this sample uses paths for the SyncFusion Big Data framework - you will need to use the correct Hadoop streaming JAR file path:

```
hadoop jar \
C:\Syncfusion\BigData\2.11.0.124\BigDataSDK\SDK\Hadoop\share\hadoop\tools\lib\hadoop-streaming-2.5.2.jar
-files "file:/c:/dotnet" \
-mapper "Sixeyed.HadoopDotNet.Mapper.exe" \
-reducer "Sixeyed.HadoopDotNet.Reducer.exe" \
-input /input/* \
-output /output-dotnet
```
