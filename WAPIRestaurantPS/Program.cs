using Microsoft.OpenApi.Models;
using Infraestructura;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Interfaces.Comandos;
using Aplicacion.Interfaces.Querys;
using Infraestructura.Comandos;
using Infraestructura.Querys;
using Aplicacion.Interfaces.Servicios;
using Aplicacion.CasosDeUso.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "RestaurantPS - Microservicios",
        Version = "v1"
    });
});

var connectionString = builder.Configuration["ConnectionString"];


builder.Services.AddDbContext<RestoDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IComandaCommand,ComandaCommand>();
builder.Services.AddTransient<IComandaMercaderiaCommand, ComandaMercaderiaCommand>();
builder.Services.AddTransient<IMercaderiaCommand, MercaderiaCommand>();

builder.Services.AddTransient<IComandaQuery, ComandaQuery>();
builder.Services.AddTransient<IMercaderiaQuery, MercaderiaQuery>();
builder.Services.AddTransient<IFormaEntregaQuery, FormaEntregaQuery>();
builder.Services.AddTransient<IComandaMercaderiaQuery, ComandaMercaderiaQuery>();
builder.Services.AddTransient<ITipoMercaderiaQuery, TipoMercaderiaQuery>();

builder.Services.AddTransient<IMercaderiaServices, MercaderiaServices>();
builder.Services.AddTransient<IComandaServices, ComandaServices>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
