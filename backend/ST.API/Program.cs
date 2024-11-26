using ST.Application.Services;
using ST.Infrastructure.Data;
using ST.Core.Interfaces;
using ST.Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register database context
builder.Services.AddDbContext<AppDbContext>(options =>
    
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Register repositories and services 
builder.Services.AddScoped<TecnicoInterface, TecnicoRepository>();
builder.Services.AddScoped<TicketInterface, TicketRepository>();
builder.Services.AddScoped<UsuarioInterface, UsuarioRepository>();


builder.Services.AddScoped<TecnicoServices>();
builder.Services.AddScoped<TicketServices>();
builder.Services.AddScoped<UsuarioServices>();

// Register IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

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