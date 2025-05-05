Risorse Azure da includere:
1.	Gruppi di risorse (Resource Groups)
•	Un gruppo di risorse per ogni ambiente (es. rg-skillbuilderlog-dev, rg-skillbuilderlog-prod).
2.	Rete virtuale (VNet)
•	Una rete virtuale con subnet dedicate:
•	Subnet per l'Application Gateway.
•	Subnet per l'Azure Container Apps.
3.	Azure Application Gateway
•	Configurato per gestire il traffico HTTP/S.
•	Collegato alla subnet dedicata nella VNet.
4.	Azure Container Apps
•	Configurato per eseguire l'applicazione.
•	Collegato alla subnet dedicata nella VNet.
5.	Azure Container Registry (ACR)
•	Per ospitare le immagini dei container.
•	Configurato con accesso autorizzato tramite Managed Identity per il Container App.
6.	Managed Identity
•	Per consentire l'accesso sicuro tra i servizi (es. Container App → ACR).
7.	Azure Monitor e Log Analytics
•	Configurato per il logging e il monitoraggio dell'infrastruttura e dell'applicazione.
8.	Parametri e variabili
•	Parametri per rendere la configurazione riutilizzabile in ambienti diversi (es. environment, location, vnetName, subnetNames, ecc.).
Struttura modulare:
•	Ogni risorsa deve essere definita in moduli separati per garantire la riusabilità e la modularità del codice Bicep.
Output richiesto:
•	Endpoint dell'Application Gateway: URL pubblico per accedere all'applicazione.
•	Credenziali del Container Registry: Per il deployment delle immagini.
•	ID della rete virtuale e delle subnet: Per configurazioni future.