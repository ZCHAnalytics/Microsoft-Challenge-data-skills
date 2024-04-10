![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/7f71eff2-3ec5-4405-bdc3-af7ae2af716e)


Tasks:
- Locate and pull the Microsoft.Azure.Cosmos SDK library from NuGet into a .NET project
- Use the SDK library to connect to an existing Azure Cosmos DB for NoSQL account from a .NET application

## 0.0. Setup the environment:

- Pre-requisites: Windows 10, Edge, .NET 6 SDK, PowerShell, Git, Windows Terminal, Visual Studio Code and extensions, Azure Cosmos DB Emulator
- Enable Azure resource providers (Subscription > Settings > Resource providers) are registered: Microsoft.DocumentDB, Microsoft.Insights, Microsoft.KeyVault, Microsoft.Search, Microsoft.Web

## 1.0. Create an Azure Cosmos DB for NoSQL account

Use the Data Explorer to create a new database and container and add new items:

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/369a1fcf-cce6-4b78-a21a-c85f9ce894dc)

1.4. Use the Data Explorer to issue a basic query

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/d06d548c-10fc-4bfa-9f99-394ff54409ef)

### 2.0. Configure throughput for Azure Cosmos DB for NoSQL with the Azure portal

### 2.1. Create a serverless account 

Select capacity mode: Serverless
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/3230f35c-c19c-4be8-a656-4cee58f6df97)

### 2.2. Create a provisioned account
Capacity mode: `Provisioned throughput`

Database id: 	`nothroughputdb`
Provision throughput:	Unchecked
container id: `requiredthroughputcontainer`

Database id:	`manualthroughputdb`
Provision throughput:	Checked
Container id:	`childcontainer`
Provision dedicated throughput for this container:	Checked

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/975beb61-6b69-4018-9638-3613172d4a70)

## 3.0. Migrate existing data using Azure Data Factory

### 3.1. Create and seed your Azure Cosmos DB for NoSQL account

- Create a `flatproducts` container manually that will be the target of the ETL transformation and load operation.
- Create new created Azure Cosmos DB account and navigate to the Keys pane for the connection details and credentials necessary to connect to the account from the SDK (URI, Primary Key).

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/b5cbe7cf-17ab-4317-91b9-4dc4c1e3873a)

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/44f12076-9235-41a2-b83a-a7b347732e90)

- In Scale & Settings node, update Manual required throughput setting from 4000 RU/s to 400 RU/s.
- Create new container called `flatproducts` for `cosmicworks` database with RU/s	400.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/29e495ef-a08b-409f-8405-d34cc9be413e)

- Create Azure Data Factory resource

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/ab63b6c9-ef39-450c-975f-f2b42627268b)

- Test `cosmicworks` database, `flatproduct` container node in Data Explorer with a new SQL query:

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c7f2e853-b45f-4dd7-a7f5-e677bcba935e)

## 4.0 Connect to Azure Cosmos DB for NoSQL with the SDK
- Create new Database (provisioned throughput). note URI, Primary Key
- View the Microsoft.Azure.Cosmos library on NuGet
- Import the Microsoft.Azure.Cosmos library into a .NET project
- Use the Microsoft.Azure.Cosmos library to configure script.cs code file.
- Test the script
  
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/8634a2dc-73c6-4501-9890-d14cbd430b23)

  
