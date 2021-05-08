# filebeat elastic search config.yml

```

filebeat.inputs:
  - type: log
    enabled: true
    paths:
      - C:/Personal/workspace/ELK-Stack/Serilog.LogFile.WebApi/Serilog.LogFile.WebApi/Logs/*.json

output.elasticsearch:
  hosts: ['http://localhost:9200']
  index: 'dosometing'

setup.template.name: 'desktop'
setup.template.pattern: 'desktop-*'
setup.ilm.enabled: false

```

# filebeat logstash config.yml

```

filebeat.inputs:
  - type: log
    enabled: true
    paths:
      - C:/Personal/workspace/ELK-Stack/Serilog.LogFile.WebApi/Serilog.LogFile.WebApi/Logs/*.json

output.logstash:
  hosts: ['localhost:5044']


```
