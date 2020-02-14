## Hadoop for .NET Developers - Module 4

### .NET Core MapReduce code

Extended examples of a mapper, combiner and reducer written in .NET Core, which can run as a Hadoop job on any supported .NET Core platform.

To build the apps, first have .NET Core installed. Then in the relevant directory (`mapper`, `combiner` or `reducer`), run:

```
dotnet restore
```

To run the apps as MapReduce jobs in Hadoop, firstly package both apps with `dotnet publish`, and copy the package files to a directory, e.g. `c:\dotnetcore`.

Sample job scripts are in the `hadoop` folder.

