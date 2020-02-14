
Thrift 0.9.1 compiler:

http://archive.apache.org/dist/thrift/0.9.1/thrift-0.9.1.exe


HBase 1.1.5 source:

 https://raw.githubusercontent.com/apache/hbase/rel/1.1.5/hbase-thrift/src/main/resources/org/apache/hadoop/hbase/thrift/Hbase.thrift

Generate source with:

 md hbase
 thrift-0.9.1.exe -r --gen csharp -o hbase hbase.thrift