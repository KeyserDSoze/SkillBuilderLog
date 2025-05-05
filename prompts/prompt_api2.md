Crea un endpoint API sicuro in ASP.NET Core seguendo queste linee guida:

1. **Validazione dell’input**
   - Usa `[ApiController]` per abilitare la validazione automatica dei parametri.
   - Applica attributi come `[Required]`, `[StringLength]`, `[Range]` o validazioni custom per garantire che i dati siano validi.
   - Usa DTO separati dal modello di dominio per evitare overposting.

2. **Gestione degli errori**
   - Restituisci codici di stato appropriati (es. 400 per input non valido, 404 per risorse non trovate, 500 per errori interni).
   - Usa `ProblemDetails` per formattare gli errori in modo standard.
   - Logga gli errori senza esporre stack trace o dettagli sensibili al client.

3. **Autenticazione e autorizzazione**
   - Usa `[Authorize]` per proteggere gli endpoint.
   - Configura policy di autorizzazione basate sui claim:
     - **Policy "HasGroupId"**: Richiede i claim `objectid` e `groupid`. Utilizzata per endpoint generali.
     - **Policy "NoGroupId"**: Richiede il claim `objectid` ma non `groupid`. Utilizzata per endpoint relativi agli utenti.
   - Non esporre dati sensibili se l’utente non ha i permessi.

4. **Protezione dei dati**
   - Non restituire mai password, token o informazioni sensibili nei payload.
   - Usa HTTPS per tutte le comunicazioni.
   - Valida l’input per prevenire attacchi di injection e parametrizza le query.

5. **Performance e scalabilità**
   - Usa `async/await` per operazioni I/O-bound.
   - Implementa paginazione per liste grandi (es. `?page=1&pageSize=10`).
   - Evita query N+1 usando `Include()` per le relazioni.

6. **Naming e struttura REST**
   - Usa naming RESTful (es. `GET /api/users`, `POST /api/users`).
   - Restituisci `201 Created` con l’header `Location` dopo un POST.
   - Segui convenzioni HTTP semantiche.

7. **Rate limiting / CORS**
   - Abilita CORS solo per origini consentite.
   - Configura rate limiting per evitare abusi (opzionale).

8. **Documentazione e discoverability**
   - Usa annotazioni XML o attributi per generare Swagger.
   - Aggiungi descrizioni chiare per ogni parametro e risposta.

---

### **Esempio pratico**
Ecco un esempio di endpoint che utilizza le policy di autorizzazione e segue le best practice:

```
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // Endpoint protetto dalla policy "NoGroupId" 
    [HttpGet]
    [Authorize(Policy = "NoGroupId")]
    public IActionResult GetUserData() { return Ok(new { message = "Access granted to User APIs with only objectid!" }); }
    // Endpoint protetto dalla policy "HasGroupId"
    [HttpPost]
    [Authorize(Policy = "HasGroupId")]
    public IActionResult CreateUser([FromBody] CreateUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 400, "Invalid input"));
        }

        // Simula la creazione di un utente
        var createdUser = new { id = Guid.NewGuid(), username = dto.Username };

        return CreatedAtAction(nameof(GetUserData), new { id = createdUser.id }, createdUser);
    }
}
public class CreateUserDto
{
    [Required][StringLength(50, MinimumLength = 3)] public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
```

### **Spiegazione dell'esempio**
1. **Validazione dell’input**:
   - Il DTO `CreateUserDto` utilizza attributi come `[Required]` e `[StringLength]` per garantire che i dati siano validi.
   - La validazione automatica è abilitata grazie a `[ApiController]`.

2. **Gestione degli errori**:
   - Se l’input non è valido, viene restituito un errore 400 con un messaggio standardizzato tramite `ProblemDetails`.

3. **Autenticazione e autorizzazione**:
   - L'endpoint `GetUserData` è protetto dalla policy `NoGroupId`, che richiede solo il claim `objectid`.
   - L'endpoint `CreateUser` è protetto dalla policy `HasGroupId`, che richiede sia `objectid` che `groupid`.

4. **Protezione dei dati**:
   - Non vengono restituiti dati sensibili come password o token.

5. **Performance e scalabilità**:
   - L'uso di `async/await` può essere aggiunto per operazioni I/O-bound (es. accesso al database).

6. **Naming e struttura REST**:
   - Gli endpoint seguono convenzioni RESTful (`GET /api/users`, `POST /api/users`).

7. **Documentazione**:
   - Gli attributi e i tipi chiari nel codice facilitano la generazione automatica di documentazione tramite Swagger.

---

### **Come utilizzare il prompt**
1. Segui le linee guida per progettare endpoint sicuri e robusti.
2. Usa l'esempio come base per implementare nuovi endpoint.
3. Adatta le policy di autorizzazione in base ai requisiti specifici del tuo progetto.

Se hai bisogno di ulteriori dettagli o esempi, fammi sapere!