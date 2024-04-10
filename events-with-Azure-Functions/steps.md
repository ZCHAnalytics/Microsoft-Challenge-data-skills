# Process Azure Cosmos DB for NoSQL data using Azure Functions

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/63f6df92-e298-41ce-ad4a-01228d5e4d72)

Task: Create an Azure Function using the Azure Cosmos DB trigger

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/a4e5faf1-bd0e-45b9-91ae-2e46c42ecd79)

## Create Application Insight

 - Create Log Analytics Workspace
 - Create Aplication Insight
 - Create an Azure Function app and Azure Cosmos DB-triggered function

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/8d39396a-c774-4654-8688-5af79aef5459)

- Implement function code in .NET
in Azure portal > Function Pane > Code + Test > run.csx
```
#r "Microsoft.Azure.DocumentDB.Core"

using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;

public static void Run(IReadOnlyList<Document> input, ILogger log)
{
    log.LogInformation($"# Modified Items:\t{input?.Count ?? 0}");

    foreach(Document item in input)
    {
        log.LogInformation($"Detected Operation:\t{item.Id}");
    }
}
```
- Seed the Azure Cosmos DB for NoSQL account with sample data
in VSC: 

`dotnet tool install cosmicworks --global --version 1.*`

`cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product`
