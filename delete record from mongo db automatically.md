### delete record from mongo db automatically after some time, lets say 90 sec in case of below example

```
db.c1.find({})

db.c1.createIndex( { "DateTime": 1 }, { expireAfterSeconds: 90 } )

db.c1.insert( { "DateTime": new Date(), "Name" : "ABC", "Mobile" : "123" } )
```


### delete record from mongo db automatically at particular dateTime, for example

```
db.c2.find({})

db.c2.createIndex( { "expireAt": 1 }, { expireAfterSeconds: 0 } )

db.c2.insert( { "expireAt": ISODate("2021-05-18T22:44:13.001+05:30"), "Name" : "111", "Mobile" : "111"} )
```
