
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/2f4438cf-1343-4e63-9712-e45c41bf0ef0)

Tasks:
- Author a change feed processor and delegate in the .NET SDK
- Author a sidecar change feed estimator in the .NET SDK

## Process change feed events using the Azure Cosmos DB for NoSQL SDK

- Create serverless account, database, two containers
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/655aaf9b-aaa6-454e-9985-384f86007d36)

## Implement the change feed processor in the .NET SDK

```
using Microsoft.Azure.Cosmos;
using static Microsoft.Azure.Cosmos.Container;

string endpoint = "<cosmos-endpoint>";
string key = "<cosmos-key>";

CosmosClient client = new CosmosClient(endpoint, key);
Container sourceContainer = client.GetContainer("cosmicworks", "products");
Container leaseContainer = client.GetContainer("cosmicworks", "productslease");

ChangesHandler<Product> handleChanges = async (
    IReadOnlyCollection<Product> changes,
    CancellationToken cancellationToken
) => {
    Console.WriteLine($"START\tHandling batch of changes...");
    foreach(Product product in changes)
    {
        await Console.Out.WriteLineAsync($"Detected Operation:\t[{product.id}]\t{product.name}");
    }
};

var builder = sourceContainer.GetChangeFeedProcessorBuilder<Product>(
        processorName: "productsProcessor",
        onChangesDelegate: handleChanges
    );

ChangeFeedProcessor processor = builder
    .WithInstanceName("consoleApp")
    .WithLeaseContainer(leaseContainer)
    .Build();

await processor.StartAsync();

Console.WriteLine($"RUN\tListening for changes...");
Console.WriteLine("Press any key to stop");
Console.ReadKey();

await processor.StopAsync();
```

## Seed your Azure Cosmos DB for NoSQL account with sample data
In a new VSC terminal:

`dotnet tool install cosmicworks --global --version 1.*`

`cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product`

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/9eec4729-f876-44b7-90dd-8c91f6b37683)



