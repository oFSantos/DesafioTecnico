using ErpProdutos.Infrastructure.CrossCutting;
using ErpProdutos.Infrastructure.Data;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://+:80");

//Add Services
builder.Services.AddControllers();

// Swagger com autenticação JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP Produtos API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT no formato: Bearer {seu token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
            new List<string>()
        }
    });
});

//JWT Configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

//CrossCutting: DbContext, Repositories, Services, SignalR...
builder.Services.AddCrossCuttingServices(builder.Configuration);

//CORS (Se quiser liberar pro frontend depois)
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("CorsPolicy", builder => 
//         builder.AllowAnyOrigin()
//                .AllowAnyMethod()
//                .AllowAnyHeader());
// });


var corsPolicy = "CorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ErpProdutosContext>();

    var retry = 0;
    var maxRetries = 10;
    var delay = 3000; // 3 segundos

    while (retry < maxRetries)
    {
        try
        {
            Console.WriteLine("Tentando conectar ao banco...");
            dbContext.Database.Migrate();
            Console.WriteLine(" Banco conectado e migrations aplicadas.");
            break;
        }
        catch (NpgsqlException ex)
        {
            if (retry == maxRetries)
            {
                Console.WriteLine("Não foi possível conectar ao banco após várias tentativas.");
                throw;
            }
            retry++;
            Console.WriteLine($"Banco não está pronto... tentativa {retry}/{maxRetries}");
            Thread.Sleep(delay);
        }
     }
}




app.UseMiddleware<ExceptionMiddleware>(); // Tratamento global de erros
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseCors(corsPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();
