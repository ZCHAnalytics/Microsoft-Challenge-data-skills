# Perform operations on multiple items in single logical units of work

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/cff3b58d-141d-43dd-9fde-cb91d4f2c30e)

## Batch multiple point operations together with the Azure Cosmos DB for NoSQL SDK
The TransactionalBatch and TransactionalBatchResponse classes together are the key to composing and decomposing operations into a single logical step.

### Creating a transactional batch
initial script:
```
using System;
using Microsoft.Azure.Cosmos;

string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";

CosmosClient client = new CosmosClient(endpoint, key);
    
Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");
Container container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId", 400);
```

This batch will insert a worn saddle and a rusty handlebar into the container with the same “used accessories” category identifier. Both items have the same logical partition key, ensuring that we will have a successful batch operation.
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/d75ca7f4-f91c-4632-a400-34e2e223f141)

## Creating an errant transactional batch
Add:
```
Product light = new("012B", "Flickering Strobe Light", "9603ca6c-9e28-4a02-9194-51cdb7fea816");
Product helmet = new("012C", "New Helmet", "0feee2e4-687a-4d69-b64e-be36afc33e74");

PartitionKey partitionKey = new ("9603ca6c-9e28-4a02-9194-51cdb7fea816");

TransactionalBatch batch = container.CreateTransactionalBatch(partitionKey)
    .CreateItem<Product>(light)
    .CreateItem<Product>(helmet);

using TransactionalBatchResponse response = await batch.ExecuteAsync();

Console.WriteLine($"Status:\t{response.StatusCode}");
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/a4585d36-e9f1-4bc3-8c7d-9eccf6047b06)




