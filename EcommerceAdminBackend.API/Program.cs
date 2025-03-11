
using System.Net;
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
using EcommerceAdminBackend.Domain.DTOs;
using EcommerceAdminBackend.Domain.DTOs.Custom;
using EcommerceAdminBackend.Domain.DTOs.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory()) 
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); 


var keyVaultUri = builder.Configuration.GetSection("KeyVault:KeyVaultURL").Value;
var clientId = builder.Configuration.GetSection("KeyVault:ClientId").Value;
var clientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret").Value;
var directoryId = builder.Configuration.GetSection("KeyVault:DirectoryId").Value;


if (!string.IsNullOrEmpty(keyVaultUri))
{
   
    var credential = new ClientSecretCredential(directoryId, clientId, clientSecret);
    
    
    builder.Services.AddSingleton(sp => new SecretClient(new Uri(keyVaultUri), credential));
    
   
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), credential);
    
    
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddSecretClient(new Uri(keyVaultUri));
        clientBuilder.UseCredential(credential);
    });
}


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));




builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 5261); 
    serverOptions.Listen(IPAddress.Any, 5262, listenOptions =>
    {
        
        listenOptions.UseHttps(httpsOptions =>
        {
            httpsOptions.AllowAnyClientCertificate();
            httpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
        });
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddControllers();

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


//builder.Services.AddScoped<IApiKeyService, ApiKeyService>();

builder.Services.AddSingleton<IApiKeyService, InMemoryApiKeyService>();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcommerceAdminBackend API", Version = "v1" });
    
   
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer [token]'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key authentication. Enter your API key",
        Name = "X-API-Key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKey"
    });

    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        },
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
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
                    "https://192.168.0.158:5173",
                    "https://10.100.0.24:5173",
                    "http://10.100.0.22:5173",
                    "https://10.100.0.22:5173"
                    
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

app.UseHttpsRedirection();
app.UseCors("AllowVueApp");



app.UseAuthentication(); 

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthorization();
//app.MapControllers();


//=============================================================================
// CUSTOMERS API ENDPOINTS
//=============================================================================
var customersGroup = app.MapGroup("/api/customers")
    .RequireAuthorization()
    .WithTags("Customers")
    .WithDescription("Operations for managing customers");

// Get filtered customers with pagination
customersGroup.MapGet("/", async (
        [AsParameters] CustomerFilterDto filter,
        [AsParameters] PaginationParameters pagination,
        ICustomerService customerService) =>
    {
        var pageNumber = pagination.PageNumber <= 0 ? 1 : pagination.PageNumber;
        var pageSize = pagination.PageSize <= 0 ? 10 : pagination.PageSize;
    
        var result = await customerService.GetFilteredAsync(filter, pageNumber, pageSize);

        if (result.Data.Count == 0)
            return Results.NotFound("No customers found matching the specified criteria.");

        return Results.Ok(result);
    })
    .WithName("GetFilteredCustomers")
    .WithOpenApi();

// Get customer by ID
customersGroup.MapGet("/{id}", async (int id, ICustomerService customerService) =>
    {
        var customer = await customerService.GetByIdAsync(id);
    
        if (customer == null)
            return Results.NotFound();

        return Results.Ok(customer);
    })
    .WithName("GetCustomerById")
    .WithOpenApi();

//=============================================================================
// ARTICLES API ENDPOINTS
//=============================================================================


var articlesGroup = app.MapGroup("/api/articles").RequireAuthorization().WithTags("Articles")
    .WithDescription("Operations for managing articles");


articlesGroup.MapGet("/", async (
        [AsParameters] ArticleFilterDto filter,
        [AsParameters] PaginationParameters pagination,
        IArticleService articleService) =>
    {
        var pageNumber = pagination.PageNumber <= 0 ? 1 : pagination.PageNumber;
        var pageSize = pagination.PageSize <= 0 ? 10 : pagination.PageSize;
    
        var result = await articleService.GetFilteredAsync(filter, pageNumber, pageSize);

        if (result.Data.Count == 0)
            return Results.NotFound("No articles found matching the specified criteria.");

        return Results.Ok(result);
    })
    .WithName("GetArticles")
    .WithOpenApi();

articlesGroup.MapGet("/{id}", async (int id, IArticleService articleService) =>
    {
        var article = await articleService.GetByIdAsync(id);
    
        if (article == null)
            return Results.NotFound($"Article with ID {id} not found.");

        return Results.Ok(article);
    })
    .WithName("GetArticleById")
    .WithOpenApi();

//=============================================================================
// ARTICLE PACKAGING BREAKDOWN API ENDPOINTS
//=============================================================================


var packagingBreakdownGroup = app.MapGroup("/api/articlepackagingbreakdown")
    .RequireAuthorization()
    .WithTags("Article Packaging Breakdowns")
    .WithDescription("Operations for managing article packaging breakdowns");


packagingBreakdownGroup.MapGet("/", async (
        [AsParameters] ArticlePackagingBreakdownFilterDto filter,
        [AsParameters] PaginationParameters pagination,
        IArticlePackagingBreakdownService articlePackagingBreakdownService) =>
    {
        var pageNumber = pagination.PageNumber <= 0 ? 1 : pagination.PageNumber;
        var pageSize = pagination.PageSize <= 0 ? 10 : pagination.PageSize;
    
        var result = await articlePackagingBreakdownService.GetFilteredAsync(filter, pageNumber, pageSize);

        if (result.Data.Count == 0)
            return Results.NotFound("No article packaging breakdowns found matching the specified criteria.");

        return Results.Ok(result);
    })
    .WithName("GetArticlePackagingBreakdowns")
    .WithOpenApi();


packagingBreakdownGroup.MapGet("/{id}", async (int id, IArticlePackagingBreakdownService articlePackagingBreakdownService) =>
    {
        var result = await articlePackagingBreakdownService.GetByIdAsync(id);
    
        if (result == null)
            return Results.NotFound($"Article packaging breakdown with ID {id} not found.");

        return Results.Ok(result);
    })
    .WithName("GetArticlePackagingBreakdownById")
    .WithOpenApi();

//=============================================================================
// ARTICLE AVAILABLE STOCK API ENDPOINTS
//=============================================================================

var availableStockGroup = app.MapGroup("/api/articlexavailablestock")
    .RequireAuthorization()
    .WithTags("Article Available Stock")
    .WithDescription("Operations for managing article available stock");


availableStockGroup.MapGet("/", async (
    [AsParameters] ArticleXAvailableStockFilterDto filter,
    [AsParameters] PaginationParameters pagination,
    IArticleXAvailableStockService articleXAvailableStockService) =>
{
    var pageNumber = pagination.PageNumber <= 0 ? 1 : pagination.PageNumber;
    var pageSize = pagination.PageSize <= 0 ? 10 : pagination.PageSize;
    
    var result = await articleXAvailableStockService.GetFilteredAsync(filter, pageNumber, pageSize);

    if (result.Data.Count == 0)
        return Results.NotFound("No article available stock found matching the specified criteria.");

    return Results.Ok(result);
})
.WithName("GetArticleXAvailableStocks")
.WithOpenApi();


availableStockGroup.MapGet("/{articleId}/{companyStockLocationId}", async (
    int articleId, 
    int companyStockLocationId,
    IArticleXAvailableStockService articleXAvailableStockService) =>
{
    var articleXAvailableStock = await articleXAvailableStockService.GetAvailableStockByIdAndLocationIdAsync(
        articleId, 
        companyStockLocationId);

    if (articleXAvailableStock == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(articleXAvailableStock);
})
.WithName("GetArticleXAvailableStockByIdAndLocationId")
.WithOpenApi();


availableStockGroup.MapGet("/{articleId}", async (
    int articleId,
    IArticleXAvailableStockService articleXAvailableStockService) =>
{
    var articleXAvailableStock = await articleXAvailableStockService.GetAvailableStockByIdAsync(articleId);

    if (articleXAvailableStock == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(articleXAvailableStock);
})
.WithName("GetArticleXAvailableStockById")
.WithOpenApi();

//=============================================================================
// API KEY MANAGEMENT ENDPOINTS
//=============================================================================


var apiKeyGroup = app.MapGroup("/api/apikey").RequireAuthorization().WithTags("API Key Management")
    .WithDescription("Operations for managing API keys");


apiKeyGroup.MapGet("/", async (HttpContext httpContext, IApiKeyService apiKeyService) =>
{
    try
    {
        var userId = httpContext.User.Identity?.Name ?? "Unknown";
        var isAuthenticated = httpContext.User.Identity?.IsAuthenticated ?? false;
    
        if (!isAuthenticated)
        {
            return Results.Unauthorized();
        }
    
        try
        {
            var apiKeyExists = await apiKeyService.IsApiKeyValidAsync();
            if (!apiKeyExists)
            {
                return Results.NotFound(new { 
                    message = "No valid API key found. Please generate one first."
                });
            }
            
            var apiKey = await apiKeyService.GetApiKeyAsync();
            var expirationDate = await apiKeyService.GetApiKeyExpirationAsync();
            
            // Calculate remaining time
            var remainingTime = expirationDate - DateTime.UtcNow;
            var remainingDays = Math.Round(remainingTime.TotalDays, 1);
            
            return Results.Ok(new { 
                apiKey = apiKey,
                expiresAt = expirationDate,
                remainingDays = remainingDays,
                user = userId
            });
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not found") || ex.Message.Contains("Failed to retrieve API key"))
            {
                return Results.NotFound(new { 
                    message = "API key not found. Please generate one first.",
                    error = ex.Message
                });
            }
        
            throw; 
        }
    }
    catch (Exception ex)
    {
        return Results.Problem(
            detail: ex.Message,
            title: "Failed to get API key",
            statusCode: 500
        );
    }
})
.WithName("GetApiKey")
.WithOpenApi();


apiKeyGroup.MapGet("/validate", async (IApiKeyService apiKeyService) =>
{
    try
    {
        var isValid = await apiKeyService.IsApiKeyValidAsync();
        var expirationDate = await apiKeyService.GetApiKeyExpirationAsync();
        var remainingTime = expirationDate - DateTime.UtcNow;
        
        return Results.Ok(new {
            isValid = isValid,
            expiresAt = expirationDate,
            remainingDays = Math.Round(remainingTime.TotalDays, 1),
            remainingHours = Math.Round(remainingTime.TotalHours, 1)
        });
    }
    catch (Exception ex)
    {
        return Results.Problem(
            detail: ex.Message,
            title: "Failed to validate API key",
            statusCode: 500
        );
    }
})
.WithName("ValidateApiKey")
.WithOpenApi();


apiKeyGroup.MapPost("/generate", async (int? expirationDays, IApiKeyService apiKeyService) =>
{
    var daysToExpire = expirationDays ?? 30;
    var (apiKey, expiresAt) = await apiKeyService.GenerateNewApiKeyAsync(daysToExpire);
        
    return Results.Ok(new { 
        apiKey = apiKey,
        expiresAt = expiresAt,
        message = "New API key generated successfully"
    });
})
.WithName("GenerateApiKey")
.WithOpenApi();


apiKeyGroup.MapGet("/test-keyvault", async (SecretClient secretClient) =>
{
    try
    {
        var secrets = secretClient.GetPropertiesOfSecretsAsync();
        var secretNames = new List<string>();
    
        await foreach (var secret in secrets)
        {
            secretNames.Add(secret.Name);
        }
    
        return Results.Ok(new { 
            message = "Key Vault connection successful", 
            secretCount = secretNames.Count,
            secretsExist = secretNames.Any(),
            secretNames = secretNames
        });
    }
    catch (Exception ex)
    {
        return Results.Problem(
            detail: ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : ""),
            title: "Key Vault connection failed",
            statusCode: 500
        );
    }
})
.WithName("TestKeyVault")
.WithOpenApi();

app.Run();
record PaginationParameters(int PageNumber = 1, int PageSize = 10);



