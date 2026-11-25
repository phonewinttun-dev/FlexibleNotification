using FlexibleNotification.Domain;
using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Providers.Email;
using FlexibleNotification.Domain.Providers.Firebase;
using FlexibleNotification.Domain.Providers.Sms;
using FlexibleNotification.Domain.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.AddStringEnumConverter());

builder.Services.AddScoped<INotificationProvider, EmailNotificationProvider>();
builder.Services.AddScoped<INotificationProvider, SMSNotificationProvider>();
builder.Services.AddScoped<INotificationProvider, FirebaseNotificationProvider>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
