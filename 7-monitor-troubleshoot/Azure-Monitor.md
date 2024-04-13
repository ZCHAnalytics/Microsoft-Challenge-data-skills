

Azure Monitor is a full stack monitoring service in Azure that provides a complete set of features to monitor Azure resources. Azure Cosmos DB creates monitoring data using Azure Monitor. Azure Monitor captures Cosmos DB's metrics and telemetry data.

After completing this module, you'll be able to:

Understand how Azure Cosmos DB uses Azure Monitor to monitor server-side metrics
Measure Cosmos DB's throughput
Observe rate-limiting events
Query telemetry logs
Measure cross-partition storage distribution throughput

Cosmos DB monitors its server-side counters using:
- Azure Monitor to monitor metrics: Azure Monitor collects Cosmos DB metrics by default. The collection includes throughput, storage availability, latency, consistency, and system level metrics.
- Azure Monitor to monitor diagnostic logs: Telemetries like events and traces are stored as logs and can be queried. 
- The Azure Cosmos DB portal: The throughput, storage availability, latency, consistency, and system level metrics can be found under the Metrics tab of the Azure Cosmos DB account.
- The Cosmos DB NoSQL API SDKs to programmatically monitor the account: Use the .NET, Java, Python, Node.js SDKs, and the headers in REST API to programmatically monitor a Cosmos DB account.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/0aa687e7-2350-4bff-8a36-b06c2435c953)
