using Api.AppSettings;
using Api.Handlers;
using Api.Services;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(typeof(RabbitMqSettings));

builder.Services.AddTransient(typeof(RabbitMqService));

// логирование
// Настройка Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddHttpLogging(options => 
    options.LoggingFields = options.LoggingFields | HttpLoggingFields.RequestBody | HttpLoggingFields.ResponseBody
);

// обработчик отправки email писем
builder.Services.AddScoped(typeof(SendEmailHandler));

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

// логирование
app.UseHttpLogging();

app.Run();
