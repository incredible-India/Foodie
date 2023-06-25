using Foodie.Database;
using Foodie.Iservices;
using Foodie.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Foodie.Authentication.IAuth;

var builder = WebApplication.CreateBuilder(args);

//adding wuthentication service

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime    = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
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
//adding jwt service
builder.Services.AddSingleton<IAuth,JWTAuth>();

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
app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
