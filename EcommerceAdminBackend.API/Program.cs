
using System.Net;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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

builder.Services.AddSwaggerGen();

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

app.UseCors("AllowVueApp");
app.UseHttpsRedirection();

// Add authentication and authorization middleware
app.UseAuthentication(); // Must come before UseAuthorization
app.UseAuthorization();


app.MapControllers();


app.Run();