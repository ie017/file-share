# Basic logstash config:

```
input { stdin { } }

output {
  elasticsearch { 
    hosts => ["localhost:9200"]
    index => "this_log_index_name"
  }
  stdout { codec => rubydebug }
}

```

# CSV logstash config with filter:

```

input {
  file {
    path => "*.csv"
    start_position => "beginning"
    sincedb_path => "NULL"
   }
}

filter {
  csv {
    separator => ","
    columns => ["id", "Name"]
  }
}

output {
  elasticsearch { 
    hosts => ["localhost:9200"]
    index => "this_csv_log_index_name"
  }
  stdout { codec => rubydebug }
}

```

# logstash file beat.conf without filter

```

input {
    beats {
	    type => "logs"
        port => "5044"
    }
}

output {
  elasticsearch { 
    hosts => ["localhost:9200"]
    index => "file_beat_logs"
  }
  stdout { codec => rubydebug }
}

```

# logstash file beat.conf with json filter

> https://www.youtube.com/watch?v=_qgS1m6NTIE&ab_channel=SundogEducationwithFrankKane

```

input {
    beats {
	    type => "logs"
        port => "5044"
    }
}

filter {
    json {
        source => "message"
        target => "log"
    }
    if [log][@l] {
    mutate { add_field => { "@level" => "%{[log][@l]}" } }
    } else {
    mutate { add_field => { "@level" => "Information" } }
    }
}

output {
  elasticsearch { 
    hosts => ["localhost:9200"]
    index => "logs_from_logstash_file_beat"
  }
  stdout { codec => rubydebug }
}

```
