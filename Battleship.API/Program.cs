using Battleship.API.Data;
using Battleship.API.Model;
using Battleship.API.Repository;
using Battleship.API.Service;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddSwaggerGen();

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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();