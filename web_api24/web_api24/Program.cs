using Microsoft.EntityFrameworkCore;
using web_api24.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//levanta la cadena, le paso el nombre
var coneccion = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(coneccion));



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//dotnet ef migrations add MigracionUsuarios
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
