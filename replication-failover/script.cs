using Microsoft.Azure.Cosmos;

string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";

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
