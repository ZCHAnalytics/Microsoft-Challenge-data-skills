![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/92ea72e9-802f-479b-94be-5e524146d3ad)

Tasks: 
- Understand how Azure Cosmos DB uses Azure Monitor to monitor server-side metrics
- Measure Cosmos DB's throughput
- Observe rate-limiting events
- Query telemetry logs
- Measure cross-partition storage distribution throughput

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/0aa687e7-2350-4bff-8a36-b06c2435c953)


## Setup
- Create provisioned throughput database account wiht NoSQL AP
- Import the Microsoft.Azure.Cosmos and Newtonsoft.Json libraries into a .NET script. In the project folder, download:
        - Microsoft.Azure.Cosmos: `dotnet add package Microsoft.Azure.Cosmos --version 3.22.1`
        - Newtonsoft.Json package: dotnet add package Newtonsoft.Json --version 13.0.1
- Run a script to create the containers and the workload
         Add URI and primary key to the Program.cs file:
         private static readonly string endpoint = "<cosmos-endpoint>";
         private static readonly string key = "<cosmos-key>";
         dotnet run

### Azure Monitor Metrics's reports
Change the default time range from ***Last 24 hours (Automatic)*** to ***30 minutes***. 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/25bf3cff-9d88-4d3e-9aba-9007607b774e)

***Total Request Units*** 

Total RUs by database to find which database is mostly used: 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/79796103-0d43-47db-b9d1-4098500b78f4)

Total RUs by container use. ***SalesOrder*** is mostly used but the value value is an aggregation of that collection name in two databases (database 2 and database 3): 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/0636d22d-0512-42a0-abfc-973406e3b5d6)

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/3633df74-115f-49f6-abb0-ccea5501c4a9)

Filter with the ***Property StatusCode***, use Values 200 and 429, Split to use ***StatusCode***. 
> unhealthy  amount of 429 (rate limiting requests) compared to status 200 (successful requests). The 429 exceptions happened because the script is sending thousands of requests per second while the provisioned throughput is set to 400 RU/s.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/706c19b0-3867-4441-b140-375a3ba6c25a)


### Which read or write operations are doing the bulk of the work. 
Create operations:  
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/f639e249-39d0-4bd9-8141-65cb092f1532)

Change split to ***PartitionKeyRangeId*** to identify which partition key range usage is warmer. The chart show us a very unhealthy system, hitting a constant 100% Normalied RU Consumption.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/02a8cbf3-f780-4cbb-928b-e28e1c86824c)


## Azure Monitor Insights reports

Normalized RU Consumption (%) By PartitionKeyRangeID chart can be used to detect hot partitions.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/ae65c875-5a29-4460-8cb3-a9a04ee631bf)

in ***Requests*** Tab, analyze the number of limiting events the account has experience (429 vs. 200) and to review the number of requests per operation type.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/55bf1965-e8ac-4e07-a21b-24994c44b858)

In ***Storage*** Tab see the growth of the document collections, the data and index usage.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/0a54aa4e-c124-40a8-a04c-99c575b99fa0)


In ***System*** Tab. If the application was creating, deleting, or querying the accounts metadata frequently, it's possible to have 429 exceptions. These charts help determine if that frequent metadata access is the cause of 429 exceptions. 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/f1de2a3c-a96b-424c-8979-477610165bf6)

 
