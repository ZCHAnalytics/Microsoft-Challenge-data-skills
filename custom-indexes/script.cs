using System;
using Microsoft.Azure.Cosmos;

string endpoint = "https://zch-sdk-cosmos-account.documents.azure.com:443/";
string key = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

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


