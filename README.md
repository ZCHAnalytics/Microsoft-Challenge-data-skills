# data-skills-challenge

## Exercise: Migrate existing data using Azure Data Factory

Migrate existing data using Azure Data Factory
In Azure Data Factory, Azure Cosmos DB is supported as a source of data ingest and as a target (sink) of data output.

In this lab, we will populate Azure Cosmos DB using a helpful command-line utility and then use Azure Data Factory to move a subset of data from one container to another.
Create and seed your Azure Cosmos DB for NoSQL account
You will use a command-line utility that creates a cosmicworks database and a products container at 4,000 request units per second (RU/s). Once created, you will adjust the throughput down to 400 RU/s.

To accompany the products container, you will create a flatproducts container manually that will be the target of the ETL transformation and load operation at the end of this lab.

VSC: `az login`
`az group create --location uksouth --name az204-cosmos-rg`
`az cosmosdb create --name solarisdb-2024 --resource-group az204-cosmos-rg`
Record the documentEndpoint shown in the JSON response.

Retrieve the primary key for the account by using the following command:
`az cosmosdb keys list --name solarisdb-2024 --resource-group az204-cosmos-rg`
`mkdir az204-cosmos`
`cd az204-cosmos`
`dotnet new console`
`code . -r`
Open Program.cs file and write: `using Microsoft.Azure.Cosmos;`
In the termimal:
dotnet add package Microsoft.Azure.Cosmos

#### Add code to connect to an Azure Cosmos DB account
#The code snippet adds constants and variables into the class and adds some error checking. Be sure to replace the placeholder values for EndpointUri and PrimaryKey following the directions in the code comments.
$ dotnet build
$ dotnet run 
![image](https://github.com/ZCHAnalytics/data-skills-challenge/assets/146954022/580b6f74-2cf7-4c99-b9c3-2554bc263c7a)

and clean up:
`az group delete --name az204-cosmos-rg --no-wait`

### Exercise - Create an Azure function triggered by a webhook
![image](https://github.com/ZCHAnalytics/data-skills-challenge/assets/146954022/7f86ddea-6ace-4b33-adc5-c2e0db02fdda)


![image](https://github.com/ZCHAnalytics/data-skills-challenge/assets/146954022/dfb5cbca-2325-4882-9459-3aadbb3963c3)
