using Microsoft.EntityFrameworkCore;
using tiendaRopa_Api.Context;

var builder = WebApplication.CreateBuilder(args);

// Agregar soporte para controladores (API)
builder.Services.AddControllers();

// Leer variables de entorno de forma segura
string dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
string dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "TiendaRopa";
string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "usuarioPorDefecto";
string dbPass = Environment.GetEnvironmentVariable("DB_PASS") ?? "contraseñaPorDefecto";

string connectionString = $"Server={dbServer};Database={dbName};User Id={dbUser};Password={dbPass};TrustServerCertificate=True;";

//Registrar el DbContext con la cadena contruida de forma dinámica
builder.Services.AddDbContext<TiendaRopaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Ejemplo de API"));
app.Run();
