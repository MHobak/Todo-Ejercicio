using Infraestructure.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Initializers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection

//Configurar contexto de base de datos
builder.Services.AddSqlServerDbContext(builder.Configuration.GetConnectionString("DBConnection"));
builder.Services.AddRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddMappers();

//configuración para CORS
builder.Services.ConfigureCors();

#endregion

var app = builder.Build();

//Seed database - insercción de datos por defecto
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

    try
	{
        var context = services.GetRequiredService<TodoDbContext>();
        InitialSeed.seed(context);
    }
	catch (Exception ex)
	{
		var logger = services.GetService<ILogger<Program>>();
		logger.LogError(ex, "Ha ocurrido un error al inizializar la base de datos");
	}

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//cors
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
