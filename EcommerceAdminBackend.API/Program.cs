
using EcommerceAdminBackend.API.Data;
using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Repositories;
using EcommerceAdminBackend.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

// all repositories 
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticlePackagingBreakdownRepository, ArticlePackagingBreakdownRepository>();
builder.Services.AddScoped<IArticleXAvailableStockRepository, ArticleXAvailableStockRepository>();

// all services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleXAvailableStockService, ArticleXAvailableStockService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseAuthorization();
app.MapControllers();
app.Run();