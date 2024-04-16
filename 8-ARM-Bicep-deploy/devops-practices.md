## Using Azure Resource Manager templates

use empty ARM json template with deploy.json and add resources to create:

```
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "resources": [
     # Create database account
      {
    "type": "Microsoft.DocumentDB/databaseAccounts",
    "apiVersion": "2021-05-15",
    "name": "[concat('csmsarm', uniqueString(resourceGroup().id))]",
    "location": "[resourceGroup().location]",
    "properties": {
        "databaseAccountOfferType": "Standard",
        "locations": [
            {
                "locationName": "westus"
            }
        ]
    }
}
```

- Create a new variable name resourceGroup:
  $resourceGroup="<resource-group-name>"
- Deploy the Azure Resource Manager template using the az deployment group create command:
  `az deployment group create --name "arm-deploy-account" --resource-group $resourceGroup --template-file .\deploy.json`

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/4fccfd07-c120-48c3-9a74-2ed40d62d18f)


  `az deployment group create --name "arm-deploy-database" --resource-group $resourceGroup --template-file .\deploy.json`
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/b08c1755-3342-4a45-80f9-4eb6dbf652c1)

- Now, we create a container with the following properties:
  Resource id:	products
  Throughput:	400
  Partition key:	/categoryId

  `az deployment group create --name "arm-deploy-container" --resource-group $resourceGroup --template-file .\deploy.json`
