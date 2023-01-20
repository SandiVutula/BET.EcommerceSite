global using BET.Data.EcommerceDbContext;
global using BET.Service.Contract;
global using BET.Service.Service;
global using Microsoft.EntityFrameworkCore;
using BET.Data.GenericRepository;
using BET.Data.GenericRepository.Implementation;
using BET.Data.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EntiyFrameworkDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BET_ConnectionString"), options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
});

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig").ToString());
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime= true,
            ValidateLifetime= true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedEmail = false)
    .AddEntityFrameworkStores<EntiyFrameworkDbContext>();

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
builder.Services.AddTransient<IRepository, EntityFrameworkRepository>();
builder.Services.AddTransient<IRepositoryReadOnly, EntityFrameworkRepositoryReadOnly>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICartService, CartService>(); 
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
