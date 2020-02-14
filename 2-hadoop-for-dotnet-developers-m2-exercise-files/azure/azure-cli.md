
## Azure CLI commands for creating Hadoop HDInsight cluster

Start a container using Microsoft's image on the Docker Hub

```
docker run -it microsoft/azure-cli
```

Inside the container, switch to ARM mode and login:

```
azure config mode arm
azure login
```

Create a resoruce group and storage account for the HDInsight cluster:

```
azure group create hadoop-dotnet-m2 NorthEurope
azure storage account create -g hadoop-dotnet-m2 --kind Storage --sku-name LRS -l NorthEurope hadoopdotnetm2
```

Get the storage account access key:

```
azure storage account keys list -g hadoop-dotnet-m2 hadoopdotnetm2
```

Use the key to create the HDInsight cluster:

```
azure hdinsight cluster create -g hadoop-dotnet-m2 -l NorthEurope --osType Windows --defaultStorageAccountName hadoopdotnetm2.blob.core.windows.net --defaultStorageAccountKey <<storage_account_key>> --defaultStorageContainer hadoop-dotnet --headNodeSize Standard_D3_v2 --workerNodeSize Standard_D3_v2 --workerNodeCount 2 --userName elton1 --password 'Plur*ls!ght1' --rdpUserName elton2 --rdpPassword 'Plur*ls!ght2' --rdpAccessExpiry '01/01/2017' --clusterType Hadoop --clusterName hadoop-dotnet-m2
```

Upload files from the container to Blob Storage - which HDInsight can use in Hadoop queries:

```
azure storage blob upload --file /postcodes.csv --blob input/postcodes.csv --account-name hadoopdotnetm2 --container hadoop-dotnet --account-key <<storage_account_key>>
```