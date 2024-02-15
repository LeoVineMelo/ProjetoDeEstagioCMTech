using Microsoft.EntityFrameworkCore;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Business;
using ProjetoCMTech.Business.Implementations;
using ProjetoCMTech.Repository;
using ProjetoCMTech.Repository.Implementations;
using Serilog;
using ProjetoCMTech.Services;
using ProjetoCMTech.Services.Implementations;
using ProjetoCMTech.Configuration;
using Microsoft.Extensions.Options;
using JWT.Builder;
using System.Net;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Rewrite;
using ProjetoCMTech.Hubs;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// configuration signalR

builder.Services.AddSignalR();

builder.Services.AddCors(config =>
{
    var policy = new CorsPolicy();
    policy.Headers.Add("*");
    policy.Methods.Add("*");
    policy.Origins.Add("*");
    policy.SupportsCredentials = true;
    config.AddPolicy("policy", policy);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000")
            .AllowCredentials();
    });
});


builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection =builder.Configuration["ConnectionStrings:PostgreeConnectionString"];

var tokenconfigurations = new TokenConf();

new ConfigureFromConfigurationOptions<TokenConf>(
   builder.Configuration.GetSection("TokenConf")
    ).Configure(tokenconfigurations);

builder.Services.AddSingleton(tokenconfigurations);

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
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenconfigurations.Issuer,
            ValidAudience = tokenconfigurations.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenconfigurations.Secret))
        };
    });


builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});



// Adicionando suporte ao contexto via EF
builder.Services.AddDbContext<PostgreSQLContext>(options =>
options.UseNpgsql(connection, npgsqlOptions => npgsqlOptions.SetPostgresVersion(new Version("16.0.1"))));

//Versioning API
builder.Services.AddApiVersioning();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "PROJETO CMTECH",
            Version = "v1",
            Description = "API RESTFULL'PROJETO CMTECH'",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name =  "Leonardo Melo",
                Url = new Uri ("https://github.com/LeoVineMelo")

            }
        });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
            "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
            "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
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
            Array.Empty<string>()
        }
    });
});

//Dependency Injection
builder.Services.AddScoped<IAtendimentoBusiness, AtendimentoBusinessImplemetation>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepositoryImplemetation>();

builder.Services.AddScoped<IChangelogBusiness, ChangelogBusinessImplemetation>();
builder.Services.AddScoped<IChangelogRepository, ChangelogRepositoryImplemetation>();

builder.Services.AddScoped<IChatAtendimentoBusiness, ChatAtendimentoBusinessImplemetation>();
builder.Services.AddScoped<IChatAtendimentoRepository, ChatAtendimentoRepositoryImplemetation>();

builder.Services.AddScoped<IDepartamentoBusiness, DepartamentoBusinessImplemetation>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepositoryImplemetation>();

builder.Services.AddScoped<IGrupoBusiness, GrupoBusinessImplemetation>();
builder.Services.AddScoped<IGrupoRepository, GrupoRepositoryImplemetation>();

builder.Services.AddScoped<IOrganizacaoBusiness, OrganizacaoBusinessImplemetation>();
builder.Services.AddScoped<IOrganizacaoRepository, OrganizacaoRepositoryImplemetation>();

builder.Services.AddScoped<IPerfilBusiness, PerfilBusinessImplemetation>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepositoryImplemetation>();

builder.Services.AddScoped<ISegmentoBusiness, SegmentoBusinessImplemetation>();
builder.Services.AddScoped<ISegmentoRepository, SegmentoRepositoryImplemetation>();

builder.Services.AddScoped<IStatusAtendimentoBusiness, StatusAtendimentoBusinessImplemetation>();
builder.Services.AddScoped<IStatusAtendimentoRepository, StatusAtendimentoRepositoryImplemetation>();

builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusinessImplemetation>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryImplemetation>();

builder.Services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();

builder.Services.AddTransient<ITokenService, TokenService>();



var app = builder.Build();

// Adaptando o IWebHostEnvironment na Program.cs (a partir do .NET6,
// a classe Startup.cs foi descontinuada)

IWebHostEnvironment env = app.Environment;

//
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<PostgreSQLContext>();
    context.Database.SetCommandTimeout(600);
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Ocorreu um erro durante a Migration");
}
//


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
            "PROJETO CMTECH - v1");
    });
}
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);
app.UseHttpsRedirection();
app.UseCors("ClientPermission");

//configuiresignalR
app.MapHub<ChatHub>("/chat");
app.UseAuthorization();
app.MapControllers();

app.Run();
