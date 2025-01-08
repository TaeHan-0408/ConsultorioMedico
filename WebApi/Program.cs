using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:3000");

builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddDbContext<ConsultorioDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAnaliticasImagenesRepository, AnaliticasImagenesRepository>();
builder.Services.AddTransient<IAseguradorasRepository, AseguradorasRepository>();
builder.Services.AddTransient<ICitasRepository, CitasRepository>();
builder.Services.AddTransient<IImagenAnaliticasCitaRepository, ImagenAnaliticasCitaRepository>();
builder.Services.AddTransient<IMedicoRepository, MedicoRepository>();
builder.Services.AddTransient<IPacienteRepository, PacienteRepository>();
builder.Services.AddTransient<ITiposImagenRepository, TiposImagenRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors", "?code = {0}");

app.Run();
