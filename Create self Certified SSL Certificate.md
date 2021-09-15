# Create public/private key files

```
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout privatekey.key -out certificate.crt
```

```
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout privatekey.key -out certificate.pem
```


# Export Certificate

```
openssl pkcs12 -inkey privatekey.key -in certificate.pem -export -out cc.pfx
```

## Reference:

![Create self Certified SSL Certificate](https://github.com/narottamgoyal/file-share/blob/main/Create%20self%20Certified%20SSL%20Certificate.gif)
