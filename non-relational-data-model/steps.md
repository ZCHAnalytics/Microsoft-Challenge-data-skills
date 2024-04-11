

## Scenario
A retail startup is designing a database to manage online orders. It provided the developer an entity-relationship model for a database design using Cosmos DB core (SQL) API. The solution needs to have the following:
- maximum scalability
- performance
- efficiency 

The following entity-relationship diagram (ER model) shows the details of the nine entities to work with. The relational model has nine entities in their own tables.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/d87566b7-f1fd-4229-bb39-138821f7682b)

## Measure performance for customer entities

in VSC repo project folder: 
```
"C:\Program Files (x86)\Microsoft SDKs\Azure\CLI2\python.exe" -m pip install pip-system-certs
az login
cd 16-measure-performance
bash init.sh
dotnet add package Microsoft.Azure.Cosmos --version 3.22.1
dotnet build
dotnet run --load-data
echo "Data load process completed."
```

## Measure performance of entities in separate containers
