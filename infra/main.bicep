@description('Location for all resources')
param location string = resourceGroup().location

@description('Environment name (e.g., dev, prod)')
param environment string

@description('Name of the virtual network')
param vnetName string

@description('Subnet names')
param subnetNames array

@description('Name of the Azure Container Registry')
param acrName string

@description('Name of the Application Gateway')
param appGatewayName string

@description('Name of the Log Analytics workspace')
param logAnalyticsName string

@description('Name of the Container App')
param containerAppName string

@description('Name of the resource group')
param resourceGroupName string

@description('Tags for resources')
param tags object = {}

resource resourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: resourceGroupName
  location: location
  tags: tags
}

module vnet 'modules/vnet.bicep' = {
  name: 'vnetDeployment'
  params: {
    location: location
    vnetName: vnetName
    subnetNames: subnetNames
    tags: tags
  }
}

module acr 'modules/acr.bicep' = {
  name: 'acrDeployment'
  params: {
    location: location
    acrName: acrName
    tags: tags
  }
}

module appGateway 'modules/appGateway.bicep' = {
  name: 'appGatewayDeployment'
  params: {
    location: location
    appGatewayName: appGatewayName
    vnetId: vnet.outputs.vnetId
    subnetId: vnet.outputs.subnetIds[0] // Assuming the first subnet is for App Gateway
    tags: tags
  }
}

module containerApp 'modules/containerApp.bicep' = {
  name: 'containerAppDeployment'
  params: {
    location: location
    containerAppName: containerAppName
    vnetId: vnet.outputs.vnetId
    subnetId: vnet.outputs.subnetIds[1] // Assuming the second subnet is for Container Apps
    acrLoginServer: acr.outputs.loginServer
    acrUsername: acr.outputs.username
    acrPassword: acr.outputs.password
    tags: tags
  }
}

module logAnalytics 'modules/logAnalytics.bicep' = {
  name: 'logAnalyticsDeployment'
  params: {
    location: location
    logAnalyticsName: logAnalyticsName
    tags: tags
  }
}

output appGatewayEndpoint string = appGateway.outputs.endpoint
output acrCredentials object = {
  username: acr.outputs.username
  password: acr.outputs.password
}
output vnetDetails object = {
  vnetId: vnet.outputs.vnetId
  subnetIds: vnet.outputs.subnetIds
}
