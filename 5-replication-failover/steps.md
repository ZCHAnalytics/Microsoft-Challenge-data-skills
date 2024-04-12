
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/267edf90-4fc6-4cd3-9508-1c1ae293c170)

Tasks:
- Distribute data across global data centers
- Configure automatic failover and do a manual failover
- Configure the Azure Cosmos DB for NoSQL .NET SDK to use a specific region

## Connect different regions with the SDK

###  Create an Azure Cosmos DB for NoSQL account
- create a database account, add two 'read' regions in Replicate data globally pane.
- create database, container and add new item
- 
### Connect to the Azure Cosmos DB for NoSQL account from the SDK

dotnet build
configure the first part of the script.cs:
```
using Microsoft.Azure.Cosmos;

string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";
```

### Configure the .NET SDK with a preferred region list

configure the second part of the script.cs

```
List<string> regions = new()
{
    "<read-region-2>",
    "<read-region-1>",
    "<write-region>"
};

CosmosClientOptions options = new () 
{ 
    ApplicationPreferredRegions = regions
};

using CosmosClient client = new(endpoint, key, options);

Container container = client.GetContainer("cosmicworks", "products");

ItemResponse<dynamic> response = await container.ReadItemAsync<dynamic>(
    "7d9273d9-5d91-404c-bb2d-126abb6e4833",
    new PartitionKey("78d204a2-7d64-4f4a-ac29-9bfc437ae959")
);

Console.WriteLine($"Item Id:\t{response.Resource.Id}");
Console.WriteLine("Response Diagnostics JSON");
Console.WriteLine($"{response.Diagnostics}");
```

dotnet run 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/8a129e29-42e9-483b-9a6c-8af558bfe26f)

