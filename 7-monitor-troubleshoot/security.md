

Tasks:
Implement network level access control
Review data encryption options
Use role-based access control (RBAC)
Access Account Resources using Microsoft Entra ID
Understand Always Encrypted

### Create an Azure Key Vault and store the Azure Cosmos DB account credentials as a secret

### Create an Azure App Service webapp in the project root directory
This requires creating  a root directory using Microsoft projects files. 
We'll create a webapp that will connect to the Azure Cosmos DB account and create some containers and documents. We won't hard code the Azure Cosmos DB credentials in this app, but instead, hard code the Secret Identifier from the key vault. We'll see how this identifier is useless without the proper rights assigned to the webapp on the Azure layer. Let's start coding.
dotnet new mvc

### Import the multiple missing libraries into the .NET script

The .NET CLI includes an [add package][docs.microsoft.com/dotnet/core/tools/dotnet-add-package] command to import packages from a pre-configured package feed. A .NET installation uses NuGet as its default package feed.

Add the [Microsoft.Azure.Cosmos][nuget.org/packages/microsoft.azure.cosmos/3.22.1] package from NuGet using the following command:

dotnet add package Microsoft.Azure.Cosmos --version 3.22.1
Add the [Newtonsoft.Json][nuget.org/packages/Newtonsoft.Json/13.0.1] package from NuGet using the following command:

dotnet add package Newtonsoft.Json --version 13.0.1
Add the [Microsoft.Azure.KeyVault][nuget.org/packages/Microsoft.Azure.KeyVault] package from NuGet using the following command:

dotnet add package Microsoft.Azure.KeyVault
Add the [Microsoft.Azure.Services.AppAuthentication][nuget.org/packages/Microsoft.Azure.Services.AppAuthentication] package from NuGet using the following command:

dotnet add package Microsoft.Azure.Services.AppAuthentication --version 1.6.2

### Adding the Secret Identifier to your webapp


### Deploy your application to Azure App Services

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/7cc52a16-456f-47e4-acf8-84a69ceb9dc8)

### Allow our app to use a managed identity
We get a user-defined message our program is sending. 

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/b80e85d2-7405-4a76-b2cf-a5316e21c039)

Bad Request Error:
the second one is a System generated one. 
What the second message means is that we have been granted access to the connect to the Key vault, but we have not been granted access to view the secret inside the vault. Let's set one final setting to fix this issue.
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/6fa66a15-11ff-4972-b168-717965eb0ff9)


### Granting our web application an access policy to the Key Vault secrets


