# Execute a query with the Azure Cosmos DB for NoSQL SDK

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/dee7aa74-2115-4af4-bd02-0a86986e96f0)

Tasks:
- Create and execute a SQL query
- Project query results
- Use built-in functions in a query

## Seed the Azure Cosmos DB for NoSQL account with data
in VSC: `dotnet tool install cosmicworks --global --version 1.*`

Run cosmicworks to seed the Azure Cosmos DB account:
`cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product`

## Iterate over the results of a SQL query using the SDK
script.cs:
```
using System;
using Microsoft.Azure.Cosmos;
string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";
CosmosClient client = new (endpoint, key);
Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");
Container container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId");

string sql = "SELECT * FROM products p";
QueryDefinition query = new (sql);

using FeedIterator<Product> feed = container.GetItemQueryIterator<Product>(
    queryDefinition: query
);
while (feed.HasMoreResults)
{
    FeedResponse<Product> response = await feed.ReadNextAsync();
    foreach (Product product in response)
    {
        Console.WriteLine($"[{product.id}]\t{product.name,35}\t{product.price,15:C}");
    }
}
```
in the new integrated environment:

`dotnet add package Microsoft.Azure.Cosmos --version 3.22.1`

`dotnet run`

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/1ea3b655-6842-46b7-9836-dc8361fdb89f)


