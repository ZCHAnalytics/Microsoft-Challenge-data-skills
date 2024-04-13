


Azure Monitor for Cosmos DB can be used to:

Monitor data
Collection and routing
Analyze metrics
Analyze logs
Create Alerts
Monitor Azure Cosmos DB Programmatically

Monitoring this metric allows us to:
- Identify operations that are consuming more request units than others.
- Identify operations that are taking more cumulative request units in a given interval of time.

By identifying the operations with higher throughput, we can for example:
- If these operations are insert and upserts, their index definition can be reviewed for over or under indexing-specific fields. Consider - include or exclude paths in their indexing policy.
- Modify the query to use and index with a filter clause.
- Use partition keys that will minimize the fan out of a query into different partitions.
- Evaluate if a smaller result set would meet the query needs.

## Methods of how to identify rate-limiting events.
429 status code error indicates that a Request rate too large exception has occurred. 
This exception means that Azure Cosmos DB requests are being rate limited.

When provisioned throughput is used, the request units per second (RU/s) is set for the workload.
If in any given second, the operations consume more RUs than the provisioned RU/s, Azure Cosmos DB will return a 429 exception.

3 main reasons for a 429 exception:
- Request rate is large.
- The request did not complete due to a high rate of metadata requests.
- The request did not complete due to a transient service error.
