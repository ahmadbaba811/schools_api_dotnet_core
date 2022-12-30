using Microsoft.EntityFrameworkCore;
using schools_api_core.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//to use use sql
builder.Services.AddDbContext<schoolDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("schCon")));

//to allow CORS
builder.Services.AddCors(p => p.AddPolicy("schCors", builder =>
{
    builder.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader();
}));

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
