global using BET.Data.EcommerceDbContext;
global using Microsoft.EntityFrameworkCore;
global using BET.Service.Contract;
global using BET.Service.Service;
using Microsoft.OpenApi.Models;
using BET.Data.Model;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EntiyFrameworkDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BET_ConnectionString"), options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", info: new OpenApiInfo
    {
        Version = "v1",
        Title = "BET E-Commerce Site API",
        Description = "A REST API that facilitates the communication between Web Front-end and Database for BET E-Commerce Site"
    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

//Here I'm just enabling CORS to allow the Angular application to consume the API Service
builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader();
}));
//Registering services
builder.Services.AddTransient<IAccountService, AccountService>();
//builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddScoped<IEmailService, EmailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
