![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c14d30b8-f9ca-4fe5-a54c-fc6c5522fab4)

# Manipulate the default indexing policy and compare RUs consumption: 
Each container has a default indexing policy with the following settings:
- The inverted index is updated for all create, update, or delete operations on an item
- All properties for every item is automatically indexed
- Range indexes are used for all strings or numbers

The policy is defined and managed in JSON object with the components: Шndexing mode, Automatic, Included Paths, and Excluded Paths.

## 0. Prepare dataset 
Create an Azure Cosmos DB for NoSQL account (provisioned throughput) and seed the account with data using VSC terminal and 'cosmicworks' CLI command:
 
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/ce815236-5bfd-4709-ab66-60adaa9a2638)


### 1. Consumption with a default indexing policy where all properties are automatically indexed
SQL query to select all products called 'HL Headsets": 

`SELECT * FROM p WHERE p.name = 'HL Headset'`

Request charge is low: 2.83 RUs

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/5324d2e0-3ef8-4e79-bbdb-8d09769dab5f)

### 2. Consumption with a  policy that indexes only 'price' property, where query does not use 'price' property
SQL Query that does not use 'price' property: `SELECT * FROM p WHERE p.name = 'HL Headset'`

Request charge has increased to 7.07 RUs

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/49da795e-adf4-46e5-a3bc-0a90d9b0074c)

### 3. Consumption with a policy that indexes only 'price' property, where uses the 'price' property
New SQL query that returns all documents where the price is greater than $3,000:
`SELECT * FROM p WHERE p.price > 3000`

Request charge decreased to 3.23 RUs

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/d36a0a87-d86b-4e84-a2da-9cab89326800)



