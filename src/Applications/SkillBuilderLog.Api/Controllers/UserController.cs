using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // Registrazione utente
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 400, "Invalid input"));
        }

        // Simula la registrazione dell'utente
        var userId = Guid.NewGuid();
        return CreatedAtAction(nameof(Register), new { id = userId }, new { id = userId, message = "User registered successfully" });
    }

    // Login utente
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 400, "Invalid input"));
        }

        // Simula il login
        return Ok(new { token = "fake-jwt-token", message = "Login successful" });
    }

    // Aggiunta di una skill personalizzata
    [HttpPost("skills")]
    [Authorize(Policy = "NoGroupId")]
    public IActionResult AddSkill([FromBody] SkillDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 400, "Invalid input"));
        }

        // Simula l'aggiunta di una skill
        var skillId = Guid.NewGuid();
        return CreatedAtAction(nameof(AddSkill), new { id = skillId }, new { id = skillId, message = "Skill added successfully" });
    }

    // Modifica di una skill personalizzata
    [HttpPut("skills/{id}")]
    [Authorize(Policy = "NoGroupId")]
    public IActionResult UpdateSkill(Guid id, [FromBody] SkillDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ProblemDetailsFactory.CreateProblemDetails(HttpContext, 400, "Invalid input"));
        }

        // Simula la modifica di una skill
        return Ok(new { id, message = "Skill updated successfully" });
    }

    // Rimozione di una skill personalizzata
    [HttpDelete("skills/{id}")]
    [Authorize(Policy = "NoGroupId")]
    public IActionResult DeleteSkill(Guid id)
    {
        // Simula la rimozione di una skill
        return Ok(new { id, message = "Skill deleted successfully" });
    }
}

// DTO per la registrazione
public class RegisterUserDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}

// DTO per il login
public class LoginUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}

// DTO per le skill
public class SkillDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }
}