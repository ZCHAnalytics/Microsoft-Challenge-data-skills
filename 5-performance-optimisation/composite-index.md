![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/6c9413e0-28e6-49e5-9372-f0bed9f74783)


# Seed database account with cosmic works dataset
- Create a cosmicworks database and a products container
```csharp
dotnet tool install cosmicworks --global --version 1.*
cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product
```
# Using default indexing policy

## Measure default SQL query request charge
1. Run the default query:
```sql
SELECT * FROM c
```
Select Query Stats to view the request unit charge in RUs - 9.28.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/f664f088-16df-43ac-b08f-5808431a8261)

2. A new SQL query that returns all name, categoryName, and price values from all documents:
```sql
SELECT p.name, p.categoryName, p.price FROM products p
```
The request unit charge is almost the same as the first query at 8.96 RUs.
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/48ef27ee-8954-4d99-bb49-9a37216e74c9)

3. A new query that returns three values from all documents ordered by `categoryName`:
```sql
SELECT p.name, p.categoryName, p.price
FROM products p
ORDER BY p.categoryName DESC
```
The request unit charge has increased to 12.96 RUs due to the ORDER BY clause.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/074ff6ac-92eb-4200-b418-50b4cc999299)

# Add a composite index to use two properties in the indexing policy
- A new SQL query that orders the results by the categoryName then by price:
```sql
SELECT p.name, p.categoryName, p.price
FROM products p
ORDER BY p.categoryName DESC, p.price ASC
```
The query should fail with the error:
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/86c13905-7be7-47b8-a46c-8947670163a8)

Add composite Index in the indexing policy with this modified JSON object and then Save the changes:
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
Re-run the sql query:

RUs 12.45

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/33c1cf1f-c9bd-4956-bdfb-f18b237c3b4b)

## Run a new query that needs composite index that uses three properties
- Create a new SQL query that orders the results by the categoryName, name, price:
```sql
SELECT p.name, p.categoryName, p.price
FROM products p
ORDER BY p.categoryName DESC, p.name ASC, p.price ASC
```
The query should fail with the error:
`![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/f1b835c1-fb5c-4465-a286-b1fb2ca138a7)

- Add `price` to the composite index in the indexing policy:
```csharp
      {
        "path": "/price",
        "order": "ascending"
      }
```
- Re-run the SQL query:
```sql
SELECT p.name, p.categoryName, p.price
FROM products p
ORDER BY p.categoryName DESC, p.name ASC, p.price ASC
```
The request charge is increased only a little and now it is 12.81 RUs.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/6820470e-5ac7-4494-aa12-58c7dda82677)
