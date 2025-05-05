Genera una pipeline YAML per Azure DevOps che implementi le seguenti best practice e funzioni:

Distribuzione dell’infrastruttura come codice usando Bicep o Terraform, in una fase separata e all'inizio della pipeline.

La pipeline deve essere idempotente.

Deve creare le risorse: Azure Container Registry, Azure Container Apps, VNet, Application Gateway.

Supportare ambienti multipli (dev, stage, prod) tramite variabili o template.

Build e deploy di un’API .NET Core:

Compilare, testare e creare l’immagine Docker.

Push dell’immagine su Azure Container Registry (ACR).

Deploy dell’immagine al Container App creato nel passaggio 1.

Build e deploy di una web app React:

Compilare con npm run build.

Creare un'immagine Docker con NGINX o simile.

Push su ACR e deploy su Container App.

Pipeline strutturata in stages:

infrastructure

build-api

build-frontend

deploy

Includi:

Linting e test automatici

Scan di sicurezza (es. trivy, SonarQube, Snyk)

Uso di Service Connections e Managed Identity

Logging e monitoraggio via Azure Monitor

Output atteso:

File YAML completo della pipeline

Eventuali script secondari (deploy.sh, dockerfile, ecc.)

Best practice seguite evidenziate nei commenti del codice