using Microsoft.Extensions.Configuration;
using DotNetEnv;
using FootballHub.Models;
using FootballHub.Services;

var builder = WebApplication.CreateBuilder(args);

// Load the environment variables from the .env file
Env.Load();

// Add services to the container.
// Configure AppSettings (API base URL) and environment variables (API key)
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Register ApiService with HttpClient and headers
builder.Services.AddHttpClient<ApiService>(client =>
{
    // Get the Base URL from appsettings
    var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
    client.BaseAddress = new Uri(apiSettings.BaseUrl);

    // Get the API Key from environment variables (.env)
    var apiKey = Environment.GetEnvironmentVariable("API_KEY");
    if (string.IsNullOrEmpty(apiKey))
    {
        throw new Exception("API key not found in environment variables.");
    }

    // Set headers for API requests
    client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Add other services (like Razor Pages)
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
