using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Providers.Email;
using FlexibleNotification.Domain.Providers.Firebase;
using FlexibleNotification.Domain.Providers.Sms;
using FlexibleNotification.Domain.Services;
using FlexibleNotification.Shared;
using Scalar.AspNetCore;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.AddStringEnumConverter());

builder.Services.AddScoped<INotificationProvider, EmailNotificationProvider>();
builder.Services.AddScoped<INotificationProvider, SMSNotificationProvider>();
builder.Services.AddScoped<INotificationProvider, FirebaseNotificationProvider>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationProvider, EmailService>();

var smtpHost = builder.Configuration["SMTP_HOST"]!;
var smtpPort = builder.Configuration.GetValue<int>("SMTP_PORT", 587);
var smtpUser = builder.Configuration["SMTP_USER"]!;
var smtpPass = builder.Configuration["SMTP_PASS"]!;
var fromAddress = new MailAddress(builder.Configuration["SMTP_FROM"]!);

builder.Services
    .AddFluentEmail(fromAddress.Address, fromAddress.DisplayName)
    .AddSmtpSender(new SmtpClient(smtpHost)
    {
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(smtpUser, smtpPass),
        EnableSsl = true,
        Port = smtpPort,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Timeout = 10000
    });

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
