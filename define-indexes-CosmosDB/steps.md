# Review the default index policy for an Azure Cosmos DB for NoSQL container with the portal

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/758215f3-5029-4de2-8c6d-10bb7944c2f6)

## View and manipulate the default indexing policy

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/18cb55fe-7f5d-456a-ab3c-3aa4c40b50aa)

Change indexing policy:
```
Within the editor, replace the content of the indexing policy to only index the /price path:

{
  "indexingMode": "consistent",
  "automatic": true,
  "includedPaths": [
    {
      "path": "/price/?"
    }
  ],
  "excludedPaths": [
    {
      "path": "/*"
    }
  ]
}
```

New SQL Query, not indexed:

`SELECT * FROM p WHERE p.name = 'HL Headset'`

Now that the name property is not indexed, the request charge has increased:

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/bce29741-ffcb-409f-a9d7-d854e49033e3)


New SQL query that will return all documents where the price is greater than $3,000:

`SELECT * FROM p WHERE p.price > 3000`

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/8ffff259-2220-4d8d-a3a6-f7326dde4293)


