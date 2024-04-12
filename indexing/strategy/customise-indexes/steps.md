![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c7d69414-aa28-45db-9b92-eab6da3a3283)

## Create a new indexing policy using the .NET SDK
The .NET SDK contains a suite of classes related to the parent `Microsoft.Azure.Cosmos.IndexingPolicy` class to build new indexing policies in code.
```csharp
using System;
using Microsoft.Azure.Cosmos;

string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";

CosmosClient client = new CosmosClient(endpoint, key);
Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");

// Create a new variable named `policy` using the default empty constructor
IndexingPolicy policy = new ();                 

// Set the `policy` variable to a value of `IndexingMode.Consistent`
policy.IndexingMode = IndexingMode.Consistent;  

// Add a new object with its `Path` property set to a value of `/*`
policy.ExcludedPaths.Add(                        
    new ExcludedPath{ Path = "/*" }
);                                               

// Add a new object with its `Path` property set to a value of `/name/?`
policy.IncludedPaths.Add(
    new IncludedPath{ Path = "/name/?" }
);                                               

// Create a new variable passing in the values `products` and `/categoryId` as constructor parameters
ContainerProperties options = new ("products", "/categoryId");

// Assign the `policy` variable to the `IndexingPolicy` property
options.IndexingPolicy = policy;                

/* Asynchronously invoke the `CreateContainerIfNotExistsAsync` method of the `database` variable passing in `options`
as a constructor parameter and storing the result in a variable of type Container named container */
Container container = await database.CreateContainerIfNotExistsAsync(options);

// Use the built-in `Console.WriteLine` static method to print the `Id` property of the `Container` class
Console.WriteLine($"Container Created [{container.Id}]");
```

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/45244fb4-04df-47fe-b392-6faedb82510e)

## Check the new indexing policy in Azure portal

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c6bc05fb-bb0b-4e19-bcd7-99f53ce49aa0)
