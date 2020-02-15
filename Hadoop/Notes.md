
imixs/hadoop
The Docker Image with a single node hadoop cluster providing the WebHDFS Rest Service Interface. 
https://hub.docker.com/r/imixs/hadoop/



curl -i -X PUT "http://192.168.99.100:50070/webhdfs/v1/tmp/testa/a.txt?user.name=livy&op=CREATE"
curl -i -X PUT "http://192.168.99.100:50070/webhdfs/v1/tmp/webhdfs?user.name=istvan&op=MKDIRS"
curl -i -X PUT "http://192.168.99.100:50070/webhdfs/v1/tmp/webhdfs/webhdfs-test.txt?user.name=istvan&op=CREATE"
curl -i -X PUT "http://192.168.99.100:50075/webhdfs/v1/tmp/webhdfs/webhdfs-test.txt?user.name=istvan&op=CREATE"

##################################################################

Make Directory

```
curl -i -X PUT "http://192.168.99.100:9870/webhdfs/v1/tmp?user.name=root&op=MKDIRS"
```

## Create File
```
curl -i -X PUT "http://192.168.99.100:9870/webhdfs/v1/tmp/b.txt?user.name=root&op=CREATE"
```

```
curl -i -X PUT -T b.txt "http://192.168.99.100:9864/webhdfs/v1/tmp/b.txt?op=CREATE&user.name=root&namenoderpcaddress=namenode:9000&createflag=&createparent=true&overwrite=false"
```









curl -i -X PUT -T a.txt  "http://192.168.99.100:9864/webhdfs/v1/tmp/a.txt?op=CREATE&user.name=root&namenoderpcaddress=namenode:9000&createflag=&createparent=true&overwrite=false"

##################################################################

curl -i -X PUT "http://192.168.99.100:9870/webhdfs/v1/tmp/webhdfs?user.name=root&op=MKDIRS"







curl -i -X PUT -T a.txt "http://192.168.99.100:9864/webhdfs/v1/tmp/testa/a.txt?op=CREATE&user.name=livy&namenoderpcaddress=namenode:9000&createflag=&createparent=true&overwrite=false"




## Redirection
curl -i -X PUT "http://192.168.99.100:9864/webhdfs/v1/tmp/testa/a.txt?user.name=livy&op=CREATE"

curl -i -X PUT -T a.txt "http://192.168.99.100:9864/webhdfs/v1/tmp/testa/a.txt?user.name=livy&op=CREATE"
                         http://xxx:50075/webhdfs/v1/tmp/testa/a.txt?op=CREATE&user.name=livy&namenoderpcaddress=xxx:8020&createflag=&createparent=true&overwrite=false




curl -i -X PUT "http://192.168.99.100:9870/webhdfs/v1/tmp/webhdfs?user.name=istvan&op=MKDIRS"



curl -i -X PUT "http://192.168.99.100:9870/webhdfs/v1/tmp/webhdfs/webhdfs-test.txt?user.name=istvan&op=CREATE"
curl -i -X PUT "http://192.168.99.100:98075/webhdfs/v1/tmp/webhdfs/webhdfs-test.txt?user.name=istvan&op=CREATE"












 curl -i -T webhdfs-test.txt "http://localhost:9864/webhdfs/v1/tmp/webhdfs/webhdfs-test.txt?op=CREATE&user.name=istvan&overwrite=false"

















curl -i -X PUT "http://<namenode host>:50070/webhdfs/v1/tmp/testa/a.txt?user.name=livy&op=CREATE"



curl -i -X PUT "http://192.168.99.100:9870/webhdfs/v1/tmp/webhdfs?user.name=istvan&op=MKDIRS"


curl -i -X PUT "http://192.168.99.100:9870/webhdfs/v1/tmp/webhdfs/webhdfs-test.txt?user.name=istvan&op=CREATE"

 curl -i -T webhdfs-test.txt "http://localhost:9864/webhdfs/v1/tmp/webhdfs/webhdfs-test.txt?op=CREATE&user.name=istvan&overwrite=false"