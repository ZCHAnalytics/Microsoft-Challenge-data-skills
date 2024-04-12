![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/3092bc28-ff3b-444f-8a27-703d3fcb5dbb)

Tools: Azure Cosmos DB for NoSQL, .NET SDK, Azure Data Factory, Azure Functions, Azure Cognitive Search, Gitbash
Visual Studio Code terminal, command-line tool 'cosmicworks' from https://www.nuget.org/packages/cosmicworks/

2024 Data Skills Challenge modules can be categorises in the following groupings:

# 0. Setup environment
- .NET SDK (not runtime) v6.0
- Visual Studio Code and C# extension, PowerShell
- Azure Cosmos DB Emulator
- CLI  'cosmicworks' CLI v1 in the Visual Studio Code: `dotnet tool install cosmicworks --global --version 1.*`
- Git repository from https://github.com/microsoftlearning/dp-420-cosmos-db-dev
  
# 1. Prepare database account in Azure 
- account with provisioned throughput capacity
- account with serverless capacity
- if required, seed the account with required datasets from cosmicworks database, using Cosmos DB account URI and Primary Key for the following command `cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product`

- Plan Resource Requirements (thoroughput)

# 2. Data Movement and Integration:
2.1. Data migration with Azure Data Factory (Spark also available)
2.2. Process bulk data
2.3. Consume a change feed using the SDK
2.4. Handle events with Azure Functions and change feed

# 3. Querying and Operations:
Configure the Azure Cosmos DB for NoSQL SDK
Author complex queries
Indexing strategy (Define and customize indexes) v
Perform cross-document transactional operations
Build multi-item transactions
Expand query and transaction functionality

# 4. Data Modelling and Design:
Implement a non-relational data model
Design a data partitioning strategy

# 5. Optimise Query and Operation Performance
Customize an indexing policy for write-heavy operations
Measure index performance
Implement integrated cache

# Monitor and troubleshoot an Azure Cosmos DB for NoSQL solution
Measure performance with Azure Monitor
Monitor responses and events analysing REST response codes
Implement backup and restore for Azure Cosmos DB for NoSQL
Implement security in Azure Cosmos DB for NoSQL (network level access control, data encryption, RBAC, Microsoft Entra ID, Always Encrypted)

# 6. Performance and Optimization:
Configure replication and manage failovers
Use consistency models
Configure multi-region write

# 6. Administration and Management:
Write management scripts
Create resource template
