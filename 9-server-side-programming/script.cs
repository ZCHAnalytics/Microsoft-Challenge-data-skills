// Add a using block for the Microsoft.Azure.Cosmos.Scripts namespace:
using Microsoft.Azure.Cosmos.Scripts;
// Update the existing variable named endpoint with its value set to the endpoint of the Azure Cosmos DB account you created earlier.
string endpoint = "<cosmos-endpoint>";

// Update the existing variable named key with its value set to the key of the Azure Cosmos DB account you created earlier.
string key = "<cosmos-key>";

// Create a new variable of type UserDefinedFunctionProperties named props using the default empty constructor:
UserDefinedFunctionProperties props = new ();

// Set the Id property of the props variable to a value of tax:
props.Id = "tax";

// Set the Body property of the props variable to a value of props.Body = "function tax(i) { return i * 1.25; }";:
props.Body = "function tax(i) { return i * 1.25; }";

// Asynchronously call the container variable's Scripts.CreateUserDefinedFunctionAsync method passing in the props variable as a parameter and saving the result in a variable named udf of type UserDefinedFunctionResponse:
UserDefinedFunctionResponse udf = await container.Scripts.CreateUserDefinedFunctionAsync(props);

// Use the built-in Console.WriteLine static method to print the Resource.Id property of the UserDefinedFunctionResponse class with a header titled Created UDF:
Console.WriteLine($"Created UDF [{udf.Resource?.Id}]");
