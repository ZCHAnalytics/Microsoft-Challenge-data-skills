![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/90f77905-433c-4e70-aa22-775806207340)

# Tune the indexing policy based on write-heavy SQL queries
Azure Cosmos DB for NoSQL is schema-agnostic and the default indexing policy includes all possible paths and values for a good balance between the thoroughness of the index and performance.

In the scenario where a significant portion of the database operations involve adding, updating, or deleting data (i.e., writing data) rather than reading data, indexing policy can be manipulated to reduce associated costs.

## Environment set up 
- Create a serverless account, database 'cosmicworks' and container 'products' in Azure portal
- Clone the required git repo with .NET project and build the project using with `dotnet build` in VSC that has a pre-built .NET application that takes a large JSON object, creates a new item in the database container.

## Check request charge for a single write operation with the default indexing policy
- Add Cosmos DB account URI and Primary Key to the `script.cs` and run `dotnet run` command. The item's unique identifier and the operation's request charge (in RUs) should be printed to the console.

RU/s charge is 48.3
  
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/2c2a641a-5026-4076-9e13-18d1c370e88b)

## Update the indexing policy to optimise writes operations
- Update indexing policy in the Data Explorer to only index two properties 'name' and 'categoryName' and exclude all others.
- Run the project using the `dotnet run` command and check the console output. 

Request charge went down to 8.38 RUs. 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/5797a2d3-1e39-49b1-b1c1-576bfdac10cd)

Since we are not indexing all the item properties, the writes' cost is significantly lower when updating the index after adding a new item. However, this can cost greatly if the reads will need to query on non-indexed properties.

## Update indexing policy mode to 'none'
If we remove any indexing from the policy (setting it to none), run `dotnet run` command and check the console output, the request charge goes further down to 7.05.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/372d9084-30cc-4601-b805-7a52d4582ddc)

Since this script is measuring the RUs when users write the item, by choosing to have no index, there is no overhead mantaining that index.
The flipside to this is that while users' writes will generate less RUs, reads' operation will be very costly.
