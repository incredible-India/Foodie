using Foodie.Database;
using Foodie.Iservices;
using Foodie.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddSwaggerGen();*/
//adding services
builder.Services.TryAddScoped<IUser, User>();
//databse connection
string? con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FoodieContext>(builder => { builder.UseSqlServer(con).EnableSensitiveDataLogging();});
//adding the cors policy
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(bulider =>
    {
        bulider.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  /*  app.UseSwagger();
    app.UseSwaggerUI();*/
}

/*app.UseHttpsRedirection();*/

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
