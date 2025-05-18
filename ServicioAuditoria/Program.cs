using Auditorias.Aplicacion.ClientesApi;
using Auditorias.Aplicacion.Comandos;
using Auditorias.Aplicacion.Consultas;
using Auditorias.Dominio.Puertos;
using Auditorias.Dominio.Servicios;
using Auditorias.Infraestructura.Repositorios;
using Auditorias.Infraestructura.RepositoriosGenericos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AuditoriaBDContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IAuditoriaRepositorio, AuditoriaRepositorio>();
builder.Services.AddScoped<IComandosAuditoria, ComandosAuditoria>();
builder.Services.AddScoped<IConsultasAuditoria, ConsultasAuditoria>();
builder.Services.AddScoped<RegistrarAuditoria>();
builder.Services.AddScoped<AuditoriasPorFecha>();
builder.Services.AddScoped<AuditoriasPorUsuario>();

builder.Services.AddHttpClient<IUsuariosApiClient, UsuariosApiClient>(client =>
{
    client.BaseAddress = new Uri("https://usuarios-596275467600.us-central1.run.app/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }