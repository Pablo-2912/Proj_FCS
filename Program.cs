using Microsoft.EntityFrameworkCore;
using Teste_FCS.Context;
using Teste_FCS.Negocio.Livro;
using Teste_FCS.Repositorio.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Db_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar ILivroRepositorio para ser resolvido como LivroRepositorio
builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>(); // ? Agora usa a interface
builder.Services.AddScoped<ILivroService, LivroService>();

var app = builder.Build();

// Faz com que não seja necessario ficar fazendo migrations 
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Db_Context>();
    try
    {
        context.Database.EnsureCreated(); // Garante a criação do banco/tabelas
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erro ao conectar e criar o banco de dados.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
