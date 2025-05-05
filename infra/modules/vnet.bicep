@description('Location for the virtual network')
param location string

@description('Name of the virtual network')
param vnetName string

@description('Subnet names')
param subnetNames array

@description('Tags for the virtual network')
param tags object = {}

resource vnet 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: vnetName
  location: location
  tags: tags
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.0.0.0/16'
      ]
    }
    subnets: [
      for subnetName in subnetNames: {
        name: subnetName
        properties: {
          addressPrefix: '10.0.${index(subnetNames, subnetName)}.0/24'
        }
      }
    ]
  }
}

output vnetId string = vnet.id
output subnetIds array = [for subnet in vnet.properties.subnets: subnet.id]
