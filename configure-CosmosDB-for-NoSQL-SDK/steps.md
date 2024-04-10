# Configure the offline Azure Cosmos DB for NoSQL SDK

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c935ed08-a990-4dee-99a0-0389ef973d6d)

Tasks:
- Use the Azure Cosmos DB emulator with the SDK
- Handle the most common connection errors with the SDK
- Configure the parallelism options in the SDK client
- Create a custom request handler to log HTTP request from the SDK

## Offline development with Azure Cosmos DB Emulator

- Start the Azure Cosmos DB Emulator
- Connect to the emulator from the SDK
Configure `script.cs` and run the following commands:
`dotnet add package Microsoft.Azure.Cosmos --version 3.22.1`
`dotnet run`

- View the changes in the emulator

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/8b00e8b1-de23-40a6-96f4-40afa293cb9d)
 
- Create and view a new container
 Add aditional code to the script.cs and run `dotnet run`

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/d3981458-042e-47a4-86d3-9996bb2fe2d2)

