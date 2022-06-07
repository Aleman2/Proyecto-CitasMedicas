using AutoMapper;
using Prueba.Entity;
using Prueba.Mapper;
using Prueba.Repository;
using Prueba.Service;
using Prueba.Service.Impl;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using System.Web.Http.Cors;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSqlServer");
builder.Services.AddDbContext<DataConte>(option =>
{
    option.UseLazyLoadingProxies().UseSqlServer(connectionString);

});



builder.Services.AddScoped<CitaRepository>();
builder.Services.AddScoped<DiagnosticoRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<MedicoRepository>();
builder.Services.AddScoped<PacienteRepository>();

builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IDiagnosticoService, DiagnosticoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();

builder.Services.AddControllers();

builder.Services.AddCors(options=>
{
options.AddDefaultPolicy(
    builder => { builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();


        }
        );
    
}

);

//AUTOMAPPER
/*var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<CitaMapper>();
    cfg.AddProfile<PacienteMapper>();
    cfg.AddProfile<UsuarioMapper>();
    cfg.AddProfile<MedicoMapper>();
    cfg.AddProfile<DiagnosticoMapper>();
});

var mapper = config.CreateMapper();*/

builder.Services.AddAutoMapper(typeof(CitaMap), typeof(PacienteMap), typeof(UsuarioMap), typeof(MedicosMap), typeof(DiagnosticoMap));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
