![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/cf3a6cf2-a806-4f51-9fba-77ba35d8d19a)

# Automate common tasks with CLI, Azure Resoure Manager, and ARM/Bicep templates

## 1. Using Azure Resource Manager templates

We first test deployment tasks separately for each resource and run the deployment together.

1.1. Deploy database account

- Using an empty ARM json template we first add database account resource
- Create a new variable name resourceGroup: `$resourceGroup="<resource-group-name>"`
- And, deploy the template:

  `az deployment group create --name "arm-deploy-account" --resource-group $resourceGroup --template-file .\deploy.json`

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/4fccfd07-c120-48c3-9a74-2ed40d62d18f)

1.2. Add database resource

  `az deployment group create --name "arm-deploy-database" --resource-group $resourceGroup --template-file .\deploy.json`

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/b08c1755-3342-4a45-80f9-4eb6dbf652c1)

1.3. Add container resource 
The container will be called 'products', has a throughput of 400 RUs and a partition key `/categoryId`.

  `az deployment group create --name "arm-deploy-container" --resource-group $resourceGroup --template-file .\deploy.json`

1.4. Check the Azure Portal

We check if the operations went as planned, with the correct resources and properties, such as a thoroughput of 400 RUs.

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/6b1bf04e-5c06-457a-a4c5-ffa4aebd115a)


## 2. Using Bicep templates

We follow similar steps when using Bicep templates, creating resources by running separate bicep files. 

az deployment group create --name "bicep-deploy-account" --resource-group $resourceGroup --template-file .\deploy.bicep

![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/e2f695b8-53f6-4295-900b-9382bb862c4d)

