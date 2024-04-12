![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/84271b02-57db-4904-ae83-136837eafd48)


In Azure Data Factory, Azure Cosmos DB is supported as a source of data ingest and as a target (sink) of data output.

In this exercise, I download relational database with five tables (customer, product, productCategory, productTag, salesOrder) and migrate a subset of data from one container to sink container using Azure Data Factory. 

## Create and seed your Azure Cosmos DB for NoSQL account
- Create Cosmos DB account (provisioned throughput), database 'cosmisworks', container in Azure Portal.
- Install the command-line tool for global use, specific to the the 'cosmicworks' database:
    `dotnet tool install cosmicworks --global --version 1.*`
-  Then run a 'cosmicworks' command to seed Azure Cosmos DB account and wait for the command to finish populating the account with a database, container 'products', and items:
    `cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product` 
- Create an additional container in Azure portal called 'flatproducts' that will be the target of the ETL transformation and load operation.

## Create Azure Data Factory resource and ingest data
- Create a resource, then ingest data by connecting to Cosmos DB account.
- Choose 'products' for the source table and 'flatproducts' for destination target.
  

