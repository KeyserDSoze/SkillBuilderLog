using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Identity.Web;
using SkillBuilderLog.Storage;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSkillBuilderLogStorage(builder.Configuration);
// Aggiungi l'autenticazione tramite Entra ID
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Configura le policy di autorizzazione
builder.Services.AddAuthorization(options =>
{
    // Policy per chi ha sia "objectid" che "groupid"
    options.AddPolicy("HasGroupId", policy =>
    {
        policy.RequireClaim("objectid");
        policy.RequireClaim("groupid");
    });

    // Policy per chi ha solo "objectid" (senza "groupid")
    options.AddPolicy("NoGroupId", policy =>
    {
        policy.RequireClaim("objectid");
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Usa l'autenticazione e l'autorizzazione
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

