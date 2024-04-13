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
