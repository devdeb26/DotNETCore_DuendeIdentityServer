using IdentityServerApp.Helpers;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer()
    .AddInMemoryClients(ClientConfiguration.Clients)
    .AddInMemoryApiScopes(ClientConfiguration.ApiScopes)
    .AddInMemoryIdentityResources(ClientConfiguration.IdentityResources)
    .AddTestUsers(ClientConfiguration.TestUsers);
    
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7235";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = "api1"
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // Add routing middleware

app.UseIdentityServer(); // IdentityServer middleware

app.UseAuthentication(); // Authentication middleware
app.UseAuthorization();  // Authorization middleware

app.MapControllers(); // Map attribute-based controllers

app.Run();
