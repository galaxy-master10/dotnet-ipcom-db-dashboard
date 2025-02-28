
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using EcommerceAdminBackend.API.Interfaces;
using EcommerceAdminBackend.API.Middlewares;
using EcommerceAdminBackend.API.Services;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Infrastructure.Persistence.Context;
using EcommerceAdminBackend.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using EcommerceAdminBackend.Application.Services;
using EcommerceAdminBackend.Application.Validators.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Azure;



var builder = WebApplication.CreateBuilder(args);


// Add configuration files: appsettings.json and environment-specific appsettings.{environment}.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path for configuration files
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Load appsettings.json

// Add Key Vault configuration
var keyVaultUri = builder.Configuration.GetSection("KeyVault:KeyVaultURL").Value;
var clientId = builder.Configuration.GetSection("KeyVault:ClientId").Value;
var clientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret").Value;
var directoryId = builder.Configuration.GetSection("KeyVault:DirectoryId").Value;

// Configure Azure Key Vault for secrets
if (!string.IsNullOrEmpty(keyVaultUri))
{
    // Create credential using the client secret
    var credential = new ClientSecretCredential(directoryId, clientId, clientSecret);
    
    // Register Secret Client for DI
    builder.Services.AddSingleton(sp => new SecretClient(new Uri(keyVaultUri), credential));
    
    // Add Key Vault as a configuration source
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), credential);
    
    // Register Azure clients
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddSecretClient(new Uri(keyVaultUri));
        clientBuilder.UseCredential(credential);
    });
}

// Setup Microsoft Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Add API Key Service
builder.Services.AddScoped<IApiKeyService, ApiKeyService>();

// Add API Key middleware
builder.Services.AddTransient<ApiKeyAuthMiddleware>();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5261); // HTTP port
    serverOptions.ListenLocalhost(5262, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS port
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

// all validators
builder.Services.AddScoped<ArticlePackagingBreakdownFilterValidator>();
builder.Services.AddSingleton<ArticleFilterValidator>();
builder.Services.AddSingleton<ArticleXAvailableStockFilterValidator>();
builder.Services.AddSingleton<CustomerFilterValidator>();



// all repositories 
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticlePackagingBreakdownRepository, ArticlePackagingBreakdownRepository>();
builder.Services.AddScoped<IArticleXAvailableStockRepository, ArticleXAvailableStockRepository>();

// all services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticlePackagingBreakdownService, ArticlePackagingBreakdownService>();
builder.Services.AddScoped<IArticleXAvailableStockService, ArticleXAvailableStockService>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    // Configure Swagger to include authentication
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "API Key authentication. Example: \"X-API-Key: {apikey}\"",
        Name = "X-API-Key",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        },
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        builder =>
        {
            builder.WithOrigins(
                    "http://localhost:5173",
                    "https://localhost:5173",  // Local HTTPS
                    "http://10.1.3.59:5173",   // Network access
                    "https://10.1.3.59:5173",  // Network HTTPS
                    "https://192.168.0.158:5173/"
                    
                    )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceAdminBackend API v1");
        c.RoutePrefix = string.Empty;  
    });
}

app.UseCors("AllowVueApp");
app.UseHttpsRedirection();

// Add authentication and authorization middleware
app.UseAuthentication(); // Must come before UseAuthorization
app.UseAuthorization();

// Add custom API Key authentication middleware
app.UseMiddleware<ApiKeyAuthMiddleware>();

app.MapControllers();


app.Run();