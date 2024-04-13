# Perform create and read point operations on items with the SDK
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/93016d7c-2900-4952-b794-392becfde8ed)

Tasks:
- Perform Create, Read, Update, and Delete operations on a specific item using the SDK
- Update the TTL value of a specific item using the SDK

script.cs:
```
using System;
using Microsoft.Azure.Cosmos;
string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";
CosmosClient client = new CosmosClient(endpoint, key);
Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");
Container container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId", 400);
```

### Create a new object of type Product named saddle
Append to the script:
```
Product saddle = new()
{
    id = "706cd7c6-db8b-41f9-aea2-0e0c7e8eb009",
    categoryId = "9603ca6c-9e28-4a02-9194-51cdb7fea816",
    name = "Road Saddle",
    price = 45.99d,
    tags = new string[]
    {
        "tan",
        "new",
        "crisp"
    }
};
await container.CreateItemAsync<Product>(saddle);
```
## Read the item info and write into the console with the SDK
Add: 
```
string id = "706cd7c6-db8b-41f9-aea2-0e0c7e8eb009";
string categoryId = "9603ca6c-9e28-4a02-9194-51cdb7fea816";
PartitionKey partitionKey = new (categoryId);
Product saddle = await container.ReadItemAsync<Product>(id, partitionKey);

Console.WriteLine($"[{saddle.id}]\t{saddle.name} ({saddle.price:C})");
```

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/727f2517-f98a-405d-bd23-682348d3ad01)

## Update product name and price with the SDK
Add:
```
string id = "706cd7c6-db8b-41f9-aea2-0e0c7e8eb009";
string categoryId = "9603ca6c-9e28-4a02-9194-51cdb7fea816";
PartitionKey partitionKey = new (categoryId);
Product saddle = await container.ReadItemAsync<Product>(id, partitionKey);

saddle.price = 32.55d;
saddle.name = "Road LL Saddle";

await container.UpsertItemAsync<Product>(saddle);
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/1b61b990-48f9-48fe-84f7-6584e5086ff7)

## Delete item with the SDK:
Add: 
```
string id = "706cd7c6-db8b-41f9-aea2-0e0c7e8eb009";
string categoryId = "9603ca6c-9e28-4a02-9194-51cdb7fea816";
PartitionKey partitionKey = new (categoryId);

await container.DeleteItemAsync<Product>(id, partitionKey);
```

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/944aaacc-0819-406d-b501-61b018aff5dd)
