✅ Prompt: Crea un endpoint API sicuro in ASP.NET Core
"Scrivi un endpoint HTTP REST in ASP.NET Core che rispetti tutte le seguenti best practice:

Validazione dell’input

Usa [ApiController] per validazione automatica dei parametri

Applica [Required], [StringLength], [Range], o validazioni custom

Usa DTO separati dal modello di dominio per evitare overposting

Gestione degli errori

Restituisci codici di stato appropriati (400, 404, 500, ecc.)

Usa ProblemDetails per formattare errori in modo standard

Logga errori senza esporre stack trace al client

Autenticazione e autorizzazione

Applica [Authorize] per proteggere gli endpoint

Controlla i ruoli/claim se necessario (es. [Authorize(Roles = "Admin")])

Non esporre dati sensibili se l’utente non ha i permessi

Protezione dei dati

Non restituire mai password, token, o info sensibili nei payload

Usa HTTPS sempre

Evita injection validando input e parametrizzando query

Performance e scalabilità

Usa async/await per chiamate I/O-bound

Implementa paginazione per liste grandi (es. ?page=1&pageSize=10)

Evita query N+1 usando Include() per le relazioni

Naming e struttura REST

Usa naming RESTful (GET /api/logs, POST /api/logs)

Restituisci 201 Created con Location dopo un POST

Segui convenzioni HTTP semantiche

Rate limiting / CORS (facoltativi ma consigliati)

Abilita CORS solo per origini consentite

(Se rilevante) configura rate limiting per evitare abusi

Documentazione e discoverability

Usa annotazioni XML o attributi per generare Swagger

Aggiungi descrizioni chiare per ogni parametro e risposta

Implementa l'endpoint seguendo queste linee guida per garantire un design sicuro, robusto e conforme agli standard moderni."