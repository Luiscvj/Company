using System.Reflection;
using API.ApplicationServices;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CompanyContext>(optios =>
{
    string ? ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
        optios.UseMySql(ConnectionStrings, ServerVersion.AutoDetect(ConnectionStrings));
});
builder.Services.AddApiVersioning();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureCors();
builder.Services.ConfigureRateLimiting();
builder.Services.AddApplicationServices();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
