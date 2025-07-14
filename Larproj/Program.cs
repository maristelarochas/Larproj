using Larproj.Application.UseCases.CreateUser;
using Larproj.Infrastruture.Persistence;
using Larproj.Infrastruture.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

optionsBuilder.UseSqlite("Data Source=larproj.db");

var app = builder.Build();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();

app.Run();