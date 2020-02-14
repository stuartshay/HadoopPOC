## Hadoop for .NET Developers - Module 3

### .NET Core MapReduce code

A simple example of a mapper and reducer written in .NET Core, which can run as an Hadoop job on any supported .NET Core platform.

To build the apps, first have .NET Core installed. Then in the relevant directory (`mapper` or `reducer`), run:

```
dotnet restore
dotnet run
```

To run the apps as a MapReduce job in Hadoop, firstly package both apps with `dotnet publish`, and copy the package files to a directory, e.g. `c:\dotnetcore`.

Then submit the streaming job - this sample uses paths for the SyncFusion Big Data framework - you will need to use the correct Hadoop streaming JAR file path:

```
hadoop jar \
C:\Syncfusion\BigData\2.11.0.124\BigDataSDK\SDK\Hadoop\share\hadoop\tools\lib\hadoop-streaming-2.5.2.jar
-files "file:/c:/dotnetcore" \
-mapper "dotnet dotnetcore/mapper.dll" \
-reducer "dotnet dotnetcore/reducer.dll" \
-input /input/* \
-output /output-dotnetcore
```
