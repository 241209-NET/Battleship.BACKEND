using System.Text;
using Battleship.API.Data;
using Battleship.API.Model;
using Battleship.API.Repository;
using Battleship.API.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(); 

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization", 
        Description = "My auth token",
        In = ParameterLocation.Header, 
        Type = SecuritySchemeType.ApiKey, 
        Scheme = "Bearer"
    }); 
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });
});

//in swagger can add token by typing "Bearer [bearertokenvalue]" and it will add it to the headers
//in "Authorize" button at top right of swagger endpoints list

builder.Services.AddHttpContextAccessor(); 

builder.Services.AddDbContext<BattleshipContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BattleshipDB")));

builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<ICellFiredService, CellFiredService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IShipService, ShipService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<ICellFiredRepository, CellFiredRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IShipRepository, ShipRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>(); 

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddAuthentication( x => 
    {
        x.DefaultAuthenticateScheme = 
        x.DefaultChallengeScheme = 
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; 
    }
).AddJwtBearer( y =>
    {
        y.SaveToken = false; 
        y.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JWTSecret"]!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
); 

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<BattleshipContext>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication(); //needed? from tutorial
app.UseAuthorization(); //needed? from tutorial

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

//app.MapIdentityApi<IdentityUser>(); //default
//app.MapIdentityApi<User>(); //our own User model as IdentityUser



app.Run();