![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/c9373c04-efad-4990-bd39-016b3da40c54)

# 1. Measure queries using default indexing policy
## 1.1. Default SQL query
The default query that returns all items has a request charge of 9.28 RUs.
```sql
SELECT * FROM c
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/f664f088-16df-43ac-b08f-5808431a8261)

## 1.2. A query that returns all values of specific properties.
Request charge for a query that returns not the values of only three properties (name, categoryName, and price) dropped to 8.96 RUs.
```sql
SELECT p.name, p.categoryName, p.price FROM products p
```

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/48ef27ee-8954-4d99-bb49-9a37216e74c9)

## 1.3. A query with an added 'Order BY' clause
The charge for the same query (return values for name, categoryName, and price) and also orders results by one property increases to 12. 96 RUs 
```sql
SELECT p.name, p.categoryName, p.price
FROM products p
ORDER BY p.categoryName DESC
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/074ff6ac-92eb-4200-b418-50b4cc999299)

# 2. Performance with a composite index to use multiple properties 
## 2.1. Ordering the results by the values of multiple properties
Adding second property to the 'ORDER BY' clause results in error due to the default indexing policy:
```sql
SELECT p.name, p.categoryName, p.price
FROM products p
ORDER BY p.categoryName DESC, p.price ASC
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/86c13905-7be7-47b8-a46c-8947670163a8)

## 2.2 Adding a composite index in the indexing policy
The same query runs successfully and shows a charge of 12.45 RUs.

Modified indexing policy added to the database settings in Data Explorer:
```csharp
{
  "indexingMode": "consistent",
  "automatic": true,
  "includedPaths": [
    {
      "path": "/*"
    }
  ],
  "excludedPaths": [],
  "compositeIndexes": [
    [
      {
        "path": "/categoryName",
        "order": "descending"
      },
      {
        "path": "/price",
        "order": "ascending"
      }
    ]
  ]
}
```
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/33c1cf1f-c9bd-4956-bdfb-f18b237c3b4b)

## 2.3. Adding third property to the ORDER BY clause
A query that adds 'price' to the ORDER BY clause results in error, as 'price' property is missing from the indexing policy. 
```sql
SELECT p.name, p.categoryName, p.price
FROM products p
ORDER BY p.categoryName DESC, p.name ASC, p.price ASC
```
`![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/f1b835c1-fb5c-4465-a286-b1fb2ca138a7)

After adding `price` to the composite index in the indexing policy, the charge is increased to 12.81 RUs.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/6820470e-5ac7-4494-aa12-58c7dda82677)
