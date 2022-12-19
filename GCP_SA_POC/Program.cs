using GCP_SA_POC.Configuration;
using GCP_SA_POC.Models;
using GCP_SA_POC.Services;

using Google.Apis.Iam.v1.Data;

using Microsoft.AspNetCore.Http.Json;

using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var svc = builder.Services;

svc.AddEndpointsApiExplorer();
svc.AddSwaggerGen();
svc.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.PropertyNamingPolicy = new JsonWithoutUnderscorePolicy();
});

var config = builder.Configuration.Get<APIConfig>();

svc.AddSingleton(config!);
svc.AddScoped<ServiceAccountsService>();
svc.AddTransient<GoogleClientFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/serviceAccounts/create", (CreateServiceAccountRequest model, ServiceAccountsService serviceAccountsService) =>
{
    return serviceAccountsService.CreateServiceAccount(model);
})
.WithName("CreateServiceAccount")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
