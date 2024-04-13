![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/a2765973-dc6e-473f-8555-b74455f0fbcf)

# Create a dedicated gateway

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/cb1b6ab5-46fc-4480-aacc-1be3c9ec1d46)

# Update .NET SDK code
For the .NET SDK client to use the integrated cache, use the dedicated gateway connection string instead of the typical connection string
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/985bea48-66a5-434c-bce5-14c7d08b505a)

```csharp
// Ensure that the connection string is set to the dedicated gateway’s connection string
string connectionString = "AccountEndpoint=https://<cosmos-account-name>.sqlx.cosmos.azure.com/;AccountKey=<cosmos-key>;";

//  .NET `CosmosClient` class must be configured using a `CosmosClientOptions` instance
CosmosClientOptions options = new()
{
    ConnectionMode = ConnectionMode.Gateway
};
CosmosClient client = new (connectionString, options);

// Configure point read operations
string id = "9DB28F2B-ADC8-40A2-A677-B0AAFC32CAC8";
PartitionKey partitionKey = new ("56400CF3-446D-4C3F-B9B2-68286DA3BB99");

// Create an object of type ItemRequestOptions.
ItemResponse<Product> response = await container.ReadItemAsync<Product>(id, partitionKey, requestOptions: operationOptions);

// To observe the RU usage, use the `RequestCharge` property of the `response` variable.
// The first invocation of this read operation will use the expected number of request units.
// Subsequent requests will not use any request units as the data will be pulled from the cache until it expires.
Console.WriteLine($"Request charge:\t{response.RequestCharge:0.00} RU/s");

// To configure a query to use the integrated cache
string sql = "SELECT * FROM products";
QueryDefinition query = new(sql);

// Create an object of type QueryRequestOptions and manually change the consistency level
QueryRequestOptions queryOptions = new()
{
    ConsistencyLevel = ConsistencyLevel.Eventual
};

// Pass in the options variable to the GetItemQueryIterator method invocation.
FeedIterator<Product> iterator = container.GetItemQueryIterator<Product>(query, requestOptions: queryOptions);

// Observe the RU usage. The first query will use the typical number of request units
// Extra queries will use no request units until the data expires in the cache.
double totalRequestCharge = 0;

// Get the RequestCharge property of each FeedResponse object associated with each page of results.
while(iterator.HasMoreResults)
{
    FeedResponse<Product> response = await iterator.ReadNextAsync();
    totalRequestCharge += response.RequestCharge;
    Console.WriteLine($"Request charge:\t\t{response.RequestCharge:0.00} RU/s");
}
// Aggregate the request charges for the entire query
Console.WriteLine($"Total request charge:\t{totalRequestCharge:0.00} RU/s");

// Option to configure cache staleness
ItemRequestOptions operationOptions = new()
{
    ConsistencyLevel = ConsistencyLevel.Eventual,
    DedicatedGatewayRequestOptions = new() 
    { 
        MaxIntegratedCacheStaleness = TimeSpan.FromMinutes(15) 
    }
}; 
```
