using System;
using Microsoft.Azure.Cosmos;

string endpoint = "https://zch-sdk-cosmos-account.documents.azure.com:443/";
string key = "xxxxxxxxxxxxxxxxxxxxxx";

CosmosClient client = new CosmosClient(endpoint, key);

Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");

Container container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId", 400);    
