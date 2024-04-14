# Paginate cross-product query results with the Azure Cosmos DB for NoSQL SDK

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/118be82b-3274-4269-9f84-20fa65f8ccc5)

Tasks:
- Author a cross-product query using the JOIN keyword
- Create a correlated subquery within a cross-product query

## Seed the Azure Cosmos DB for NoSQL account with data

`dotnet tool install cosmicworks --global --version 1.*`

`cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product`

## Paginate through small result sets of a SQL query using the SDK

```
using System;
using Microsoft.Azure.Cosmos;
string endpoint = "https://zch-sdk-cosmos-account.documents.azure.com:443/";
string key = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

CosmosClient client = new CosmosClient(endpoint, key);
Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");
Container container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId");

string sql = "SELECT p.id, p.name, p.price FROM products p ";
QueryDefinition query = new (sql);
QueryRequestOptions options = new ();
options.MaxItemCount = 50;
FeedIterator<Product> iterator = container.GetItemQueryIterator<Product>(query, requestOptions: options);
while (iterator.HasMoreResults)
{
    FeedResponse<Product> products = await iterator.ReadNextAsync();
    foreach (Product product in products)
    {
        Console.WriteLine($"[{product.id}]\t[{product.name,40}]\t[{product.price,10}]");
    }
    Console.WriteLine("Press any key for next page of results");
    Console.ReadKey();
}
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/013fc5f0-eea5-4629-8438-c0aa11870640)



