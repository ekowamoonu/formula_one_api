using Microsoft.EntityFrameworkCore;
using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.DataService.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//get connections string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//initalising Db context inside the DI container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
