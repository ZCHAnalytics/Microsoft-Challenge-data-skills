![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/90f77905-433c-4e70-aa22-775806207340)

2,3 
# Tune the indexing policy based on your SQL queries
Azure Cosmos DB for NoSQL is schema-agnostic and the default indexing policy includes all possible paths and values for a good balance between the thoroughness of the index and performance.
Common patterns for adjusting an indexing policy and the resultant index.

Tasks:
Customize an indexing policy for read-heavy workloads
Customize an indexing policy for write-heavy workloads
Understand which queries will require a seek vs. a scan. 

## Create a serverless Azure Cosmos DB for NoSQL account
- Clone the required git repo with .NET project
- Create a serverless account, database 'cosmicworks' and container 'products'

## Run the test .NET application using the default indexing policy
test .NET application that will take a large JSON object and create a new item in the Azure Cosmos DB for NoSQL container. 
Once the single write operation is complete, the application will output the item’s unique identifier and RU charge to the console window.

- Build the project using the command `dotnet build` in VSC terminal.
- Add Cosmos DB account URI and Primary Key to the `script.cs` and build and run `dotnet run` command. The item's unique identifier and the operation's request charge (in RUs) should be printed to the console.
- RU/s charge is 48.38
  
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/2c2a641a-5026-4076-9e13-18d1c370e88b)

## Update the indexing policy to optimise writes operations
Update indexing policy in the Data Explorer to only index "/name/?" and "/categoryName/?" and exclude all other paths.
Run the project using the `dotnet run` command and the console output shows that charge for this writes' operation went down to 8.38 RUs. 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/5797a2d3-1e39-49b1-b1c1-576bfdac10cd)

Since we are not indexing all the item properties, the writes' cost is significantly lower when updating the index. However, this can cost greatly if the reads will need to query on properties that are not indexed.

## Read-heavy - update indexing policy mode to 'none'
If we remove indexing from the policy (setting it to none), run `dotnet run` command and check the console output, it went further down to 7.05.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/372d9084-30cc-4601-b805-7a52d4582ddc)

Since this script is measuring the RUs when users write the item, by choosing to have no index, there is no overhead mantaining that index.
The flipside to this is that while users' writes will generate less RUs, reads' operation will be very costly.
