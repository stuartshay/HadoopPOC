## Hadoop for .NET Developers - Module 5

### .NET Core Hive Transform 

Example app which can be used as a User Defined Function in a Hive query.

This sample expects two fields in each input line, formats them and writes a single field in the output.

To build the app run:

```
dotnet restore
dotnet publish
```

And then create a `/dotnetcore` folder in HDFS and copy the published output there.

Sample HiveQL query using the app is in the `demo1-hive.txt` file.
