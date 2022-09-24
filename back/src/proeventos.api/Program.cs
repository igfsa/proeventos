// A partir do .net 6, a classe startup não é mais usada e as configurações sçao feitas no arquivo Program

using Microsoft.EntityFrameworkCore;
using proeventos.api.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
// O comando acima faz com que ao identificar referências cíclicas, as mesmas sejam ignoradas
// (no caso, causadas ao acessar a categoria de um evento, por exemplo, que ira chamar os eventos afiliados a ela, que chamarão suas categorias e assim sucessivamente)



// Corresponde à classe ConfigureServices

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 8 - Definir a string de conexão, definir o provedor e *obter a string de conexão* 
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// 9 - Registrar o contexto como um serviço
builder.Services.AddDbContext<DataContext>(options => 
    options.UseMySql(mySqlConnection,
    ServerVersion.AutoDetect(mySqlConnection)
));
        
    


var app = builder.Build();

// Corresponde à classe Configure()

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(access => access.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.MapControllers();

app.Run();
