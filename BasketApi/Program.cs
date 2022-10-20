using BasketApi.Data;
using BasketApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("DbConnection"), new MySqlServerVersion(new Version(8, 0))));
builder.Services.AddControllers();
builder.Services.AddScoped<PlayerService, PlayerService>();
builder.Services.AddScoped<TeamService, TeamService>();
builder.Services.AddScoped<PossitionService, PossitionService>();
builder.Services.AddScoped<CountryService, CountryService>();
builder.Services.AddScoped<GameService, GameService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
