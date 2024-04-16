param location string = resourceGroup().location

resource Account 'Microsoft.DocumentDB/databaseAccounts@2021-05-15' = {
  name: 'bicep-together-${uniqueString(resourceGroup().id)}'
  location: location
  properties: {
    databaseAccountOfferType: 'Standard'
    locations: [
      { 
        locationName: 'uksouth' 
      }
    ]
  }
}

resource Database 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2021-05-15' = {
  name: 'solaris'
  parent: Account
  properties: {
    resource: {
      id: 'solaris'
    }
  }
}

resource Container 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers@2021-05-15' = {
  name: 'planets'
  parent: Database
  properties: {
    options: {
      throughput: 400
    }
    resource: {
      id: 'planets'
      partitionKey: {
        paths: [
          '/orbitId'
        ]
      }
    }
  }
}
