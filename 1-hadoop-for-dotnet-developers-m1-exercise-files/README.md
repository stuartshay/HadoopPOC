
Hadoop for .NET Developers - Module 1
=====================================

In Module 1, I show a simple Java MapReduce program running on a Hadoop cluster in Docker.

Module 2 shows options for running Hadoop on Windows, but if you are comfortable with Docker you can follow along with the demos with the instructions below.

*Note* these instructions assume you are familiar with Docker. If you're not, then Module 2 of the course shows some easier ways to get started with Hadoop on Windows.


Pre-requisites
--------------

* Java
* Maven
* Visual Studio Code
* Docker and Docker Compose (or the Docker Toolbox)


Running the Hadoop Cluster
--------------------------

Build the Docker image from the command line by navigating to the `Docker/hadoop-dotnet` folder and running: `docker build -t sixeyed/hadoop-dotnet-master:2.7.2`.

Then back up one level to the Docker folder and start the cluster by running `docker-compose up -d`. That will start five containers - one master and four worker nodes.


Uploading the data to HDFS
--------------------------

You can download the same data file I use from the UK government website, at https://is.gd/oJHuzs. That will give you a 660MB CSV file, which I renamed to postcodes.csv.

Copy the file to one of the Hadoop containers (e.g. the master), then put the file in HDFS by running:

```
docker cp postcodes.csv hadoop-dotnet-master:/tmp/postcodes.csv
docker exec -it hadoop-dotnet-master bash
hadoop fs -mkdir /input
hadoop fs -put /tmp/postcodes.csv /input/postcodes.csv
```

Building the MapReduce job
--------------------------

Open the `java` folder in VS Code and build it using Ctrl-Shift-B. That runs the Maven build and will create the output JAR in the `target` folder.


Running the MapReduce job
-------------------------

Copy the JAR file to one of the Hadoop containers (e.g. the master), then execute the job in YARN by running:

```
docker cp my-file.jar hadoop-dotnet-master:/tmp/my-file.jar 
docker exec -it hadoop-dotnet-master bash
hadoop jar /tmp/my-file.jar /input /output
```

You can monitor the job from the YARN UI, by browsing to http://[hadoop-dotnet-master]:8088.

