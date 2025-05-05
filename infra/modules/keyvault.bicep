@description('Modulo per la creazione di un Key Vault')
param keyVaultName string

@description('Gruppo di risorse in cui creare il Key Vault')
param resourceGroupName string

@description('Location del Key Vault')
param location string

@description('Lista di oggetti con accesso al Key Vault')
param accessPolicies array

resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: keyVaultName
  location: resourceGroup().location
  properties: {
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: subscription().tenantId
  }
}

output keyVaultId string = keyVault.id