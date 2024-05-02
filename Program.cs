
using Microsoft.EntityFrameworkCore;
using  insurance.Models;

var builder = WebApplication.CreateBuilder(args);

String connectionString = builder.Configuration.GetConnectionString("Insurance");
builder.Services.AddDbContext<InsurancesContext>(option =>
{
	option.UseSqlServer(connectionString);
}
	);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
