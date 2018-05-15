srihash-cli
-----------

A command-line utility for generating the hash used for [subresource integrity (SRI)](https://developer.mozilla.org/en-US/docs/Web/Security/Subresource_Integrity) checks in modern browsers.

### Get started

Install:
```
$ dotnet tool install -g srihash-cli
```

Generate the hash:
```
$ srihash https://ajax.aspnetcdn.com/ajax/jquery/jquery-3.3.1.min.js
sha384-ifv0TYDWxBHzvAk2Z0n8R434FL1Rlv/Av18DXE43N/1rvHyOG4izKst0f2iSLdds
```

Generate the full HTML tag:
```
$ srihash --html https://ajax.aspnetcdn.com/ajax/jquery/jquery-3.3.1.min.js
<script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-3.3.1.min.js" integrity="sha384-tsQFqpEReu7ZLhBV2VZlAu7zcOV+rXbYlF2cqB8txI/8aZajjp4Bqd+V6D5IgvKT" crossorigin="anonymous"></script>
```
