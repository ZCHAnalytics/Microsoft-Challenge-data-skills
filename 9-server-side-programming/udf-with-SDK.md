![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/b15ec078-5e49-4a34-a4a7-5b364a01c7d5)


The .NET SDK for Azure Cosmos DB for NoSQL can be used to manage and invoke server-side programming constructs directly from a container. 
When preparing a new container, it may make sense to use the .NET SDK to publish UDFs directly to a container instead of performing the tasks manually using the Data Explorer.

### 1. Seed the Azure Cosmos DB for NoSQL account with data
The cosmicworks command-line tool deploys sample data to any Azure Cosmos DB for NoSQL account. The tool is open-source and available through NuGet.

1.1. Install the cosmicworks command-line tool for global use on the machine:

`dotnet tool install cosmicworks --global --version 1.*`

1.2. Run cosmicworks to seed the database account with the following command-line options:
`cosmicworks --endpoint <cosmos-endpoint> --key <cosmos-key> --datasets product`

## 2. Create a user-defined function (UDF) using the .NET SDK

The Container class in the .NET SDK includes a `Scripts` property that is used to perform CRUD operations against Stored Procedures, UDFs, and Triggers directly from the SDK.
We create a new UDF and then push that UDF to an Azure Cosmos DB for NoSQL container. 
The UDF that we will create using the SDK, will compute the price of the product with the tax, which will let us run SQL queries on the products using their price with the tax.

2.1. Configure script.cs code in VSC, consisting of:

- block for the Microsoft.Azure.Cosmos.Scripts namespace
`using Microsoft.Azure.Cosmos.Scripts;`
- variable named endpoint with its value set to the endpoint of the Azure Cosmos DB account
`string endpoint = "<cosmos-endpoint>";`
- variable named key with its value set to the primary key of the Azure Cosmos DB account
`string key = "<cosmos-key>";`
- a new variable of type UserDefinedFunctionProperties named props using the default empty constructor:
`UserDefinedFunctionProperties props = new ();`
- the Id property of the props variable set to a value of tax:
`props.Id = "tax";`
- the Body property of the props variable:
`props.Body = "function tax(i) { return i * 1.25; }";`
- Asynchronously call the container variable's Scripts.CreateUserDefinedFunctionAsync method passing in the props variable as a parameter and saving the result in a variable named udf of type UserDefinedFunctionResponse:
`UserDefinedFunctionResponse udf = await container.Scripts.CreateUserDefinedFunctionAsync(props);`
- Use the built-in Console.WriteLine static method to print the Resource.Id property of the UserDefinedFunctionResponse class with a header titled Created UDF:
`Console.WriteLine($"Created UDF [{udf.Resource?.Id}]");`

Save the file and build and run the project:
`dotnet run`

📝 The script will now output the name of the newly created UDF:

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/d1cba19c-50a2-4e70-84e8-7140c4337bae)


## Test the UDF using the Data Explorer

In Azure Data Explorer, create a new SQL query that will return all documents with two price values projected. The first value is the raw price value from the container, and the second value is the price value as calculated by the UDF:
`SELECT p.id, p.price, udf.tax(p.price) AS priceWithTax FROM products p`

📝 The priceWithTax field should have a value that is 25% larger than the price field.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/180e8c5a-74f0-404e-b508-50e4a5296c5d)
