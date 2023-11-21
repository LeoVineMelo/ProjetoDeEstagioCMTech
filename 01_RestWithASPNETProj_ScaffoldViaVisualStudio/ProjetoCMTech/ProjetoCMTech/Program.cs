using Microsoft.EntityFrameworkCore;
using ProjetoCMTech.Model.Context;
using ProjetoCMTech.Business;
using ProjetoCMTech.Business.Implementations;
using ProjetoCMTech.Repository;
using ProjetoCMTech.Repository.Implementations;
using Serilog;
using EvolveDb;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection =builder.Configuration["PostgreeConnection:PostgreeConnectionString"];

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
 options.UseNpgsql(connection, npgsqlOptions => npgsqlOptions.SetPostgresVersion(new Version("16.0.0"))));

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

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplemetation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplemetation>();

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

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

if (env.IsDevelopment())
{
	try
	{
		if (connection != null)
		    MigrarBaseDeDados(connection);
        }
	catch (Exception ex)
	{
		Log.Error("A string de conexão não pode ser nula: ", ex);
		throw;
	}
}
 
void MigrarBaseDeDados(string connection)
{
    try
    {
        var envConnection = new Npgsql.NpgsqlConnection(connection);
        var evolve = new Evolve(envConnection, msg => Log.Information(msg))
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Erro na migração da base de dados: ", ex);
        throw;
    }

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
}
