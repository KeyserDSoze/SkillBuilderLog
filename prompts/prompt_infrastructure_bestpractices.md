Crea una configurazione infrastrutturale per un'applicazione da distribuire su Azure, rispettando le seguenti best practice obbligatorie:

L'applicazione deve essere eseguita su Azure Container Apps (non usare App Service o VM).

Deve essere sempre incluso un Azure Application Gateway per gestire il traffico HTTP/S.

Il traffico deve passare tramite Application Gateway e poi essere instradato al Container App.

Deve essere previsto un Azure Container Registry (ACR) per ospitare le immagini dei container.

La configurazione deve includere:

Rete virtuale (VNet) con subnet dedicate

Application Gateway in subnet separata

Container App con binding alla VNet

ACR con accesso autorizzato per il Container App

Gruppi di risorse ben definiti

Utilizza Managed Identity dove possibile (per accesso tra servizi).

La soluzione deve essere modulare e infrastruttura-as-code, ad esempio con Bicep o Terraform.

Deve prevedere la configurazione per il logging e il monitoraggio tramite Azure Monitor e Log Analytics.

Usa parametri e variabili per rendere la configurazione riutilizzabile in ambienti diversi (dev/stage/prod).

Per i secret usa sempre keyvault.

Dividi il codice bicep o terraform sempre in moduli.

Output richiesto:

Codice completo (Terraform o Bicep)

Eventuali parametri da specificare

Istruzioni per il deployment