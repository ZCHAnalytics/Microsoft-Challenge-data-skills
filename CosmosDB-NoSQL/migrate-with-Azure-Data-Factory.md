# Migrate existing data using Azure Data Factory

## 1. Create and seed your Azure Cosmos DB for NoSQL account
- create database 'cosmicworks', notice in `keys` pane the URI and primary key.
![image](https://github.com/ZCHAnalytics/data-skills-challenge/assets/146954022/a2450293-88bd-473e-bb6b-5ad186a45630)

  
- Visual Studio Code:
- dotnet tool install cosmicworks --global --version 1.*
cosmicworks --endpoint <> --key <> --datasets product

- in Azure portal Data Explorer - create 'flatproducts' container at 400 request units per second (RU/s).

## 2. Create Azure Data Factory resource
Select + Create a resource, search for Data Factory, and then create a new Data Factory resource with the following settings, leaving all remaining settings to their default values:

![image](https://github.com/ZCHAnalytics/data-skills-challenge/assets/146954022/6557e701-9b07-48d2-b575-705516af059b)

From the home screen. Select the Ingest option to begin the quick wizard to perform a one-time copy data at scale operation and move to the Properties step of the wizard.

Starting with the Properties step of the wizard, in the Task type section, select Built-in copy task.

In the Task cadence or task schedule section, select Run once now and then select Next to move to the Source step of the wizard.

In the Source step of the wizard, in the Source type list, select Azure Cosmos DB for NoSQL.

In the Connection section, select + New connection.

In the New connection (Azure Cosmos DB for NoSQL) popup, configure the new connection with the following values, and then select Create:
Back in the Source data store section, within the Source tables section, select Use query.

In the Table name list, select products.

![image](https://github.com/ZCHAnalytics/data-skills-challenge/assets/146954022/ecb0c7ac-3a0b-4c93-85ac-2a2249364f5a)


