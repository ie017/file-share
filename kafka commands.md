### zookeeper
```
.\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties
```

### Kafka
```
.\bin\windows\kafka-server-start.bat .\config\server.properties
```

### Create Topic

```
.\bin\windows\kafka-topics.bat --create --zookeeper localhost:2181 --replication-factor 1 --partitions 1 --topic TestTopic123456
```

### Describe Topic

```
.\bin\windows\kafka-topics.bat --bootstrap-server localhost:9092 --describe --topic TestTopic123456
```

### list topic

```
.\bin\windows\kafka-topics.bat --list --zookeeper localhost:2181

.\bin\windows\kafka-topics.bat --list --bootstrap-server localhost:9092
```

### Send messages

```
.\bin\windows\kafka-console-producer.bat --broker-list localhost:9092 --topic TestTopic123456

.\bin\windows\kafka-console-producer.bat --bootstrap-server localhost:9092 --topic TestTopic123456
```

### Consume messages
```
.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic TestTopic123456  --from-beginning

.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic TestTopic123456

```

### Consume List

```
.\bin\windows\kafka-consumer-groups.bat --list --bootstrap-server localhost:9092
```

### describe consumer-groups

```
.\bin\windows\kafka-consumer-groups.bat --bootstrap-server localhost:9092 --describe --group NewApp2
```

# Install and run Zookeeper and Kafka via [NSSM](https://nssm.cc/download) using powershell

### Get all service list installed vis NSSM

```
Get-WmiObject win32_service | ?{$_.PathName -like '*nssm*'} | select Name, DisplayName, State, PathName
```

### Install zookeeper
```
.\nssm.exe install zookeeper C:\kafka\bin\windows\zookeeper-server-start.bat C:\kafka\config\zookeeper.properties
```

### Start zookeeper

```
.\nssm.exe start zookeeper
```

### Install kakfa

```
.\nssm.exe install kafka C:\kafka\bin\windows\kafka-server-start.bat C:\kafka\config\server.properties

```

### Start kafka

```
.\nssm.exe start kafka
```
