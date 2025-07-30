using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Routes;

var builder = WebApplication.CreateBuilder(args);

// Usa a string de conexão da variável de ambiente
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplica migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Context>();
    db.Database.Migrate();
}

// Swagger em dev ou produção
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.EstudanteRoutes();
app.CursoRoutes();

app.Run();





