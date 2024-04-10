# Configure an Azure Cosmos DB for NoSQL container's index policy using the SDK

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/39c6de05-922a-4823-a80d-8b58c33b5f5d)

Tasks:
Implement a correlated subquery
Create a cross-product query

## Create a new indexing policy using the .NET SDK
```
using System;
using Microsoft.Azure.Cosmos;

string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";

CosmosClient client = new CosmosClient(endpoint, key);
Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");

IndexingPolicy policy = new ();
policy.IndexingMode = IndexingMode.Consistent;
policy.ExcludedPaths.Add(
    new ExcludedPath{ Path = "/*" }
);
policy.IncludedPaths.Add(
    new IncludedPath{ Path = "/name/?" }
);

ContainerProperties options = new ("products", "/categoryId");
options.IndexingPolicy = policy;

Container container = await database.CreateContainerIfNotExistsAsync(options);
Console.WriteLine($"Container Created [{container.Id}]");
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/45244fb4-04df-47fe-b392-6faedb82510e)

New indexing policy in Azure portal:

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c6bc05fb-bb0b-4e19-bcd7-99f53ce49aa0)
