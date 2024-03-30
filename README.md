# data-skills-challenge

## Exercise: Migrate existing data using Azure Data Factory

Migrate existing data using Azure Data Factory
In Azure Data Factory, Azure Cosmos DB is supported as a source of data ingest and as a target (sink) of data output.

In this lab, we will populate Azure Cosmos DB using a helpful command-line utility and then use Azure Data Factory to move a subset of data from one container to another.
Create and seed your Azure Cosmos DB for NoSQL account
You will use a command-line utility that creates a cosmicworks database and a products container at 4,000 request units per second (RU/s). Once created, you will adjust the throughput down to 400 RU/s.

To accompany the products container, you will create a flatproducts container manually that will be the target of the ETL transformation and load operation at the end of this lab.
