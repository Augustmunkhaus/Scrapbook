using Microsoft.EntityFrameworkCore;
using ScrapBook.Components;
using ScrapBook.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();  
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//  DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<JourneyRepository>();
builder.Services.AddScoped<JourneyImageRepository>();
builder.Services.AddScoped<IJourneyRepository, JourneyRepository>();
builder.Services.AddScoped<IJourneyImageRepository, JourneyImageRepository>();

// Retrieve BaseAddress from appsettings.json
var baseAddress = builder.Configuration["BaseAddress"];

// Register HttpClient
builder.Services.AddHttpClient("ScrapBookAPI", client =>
{
    if (!string.IsNullOrEmpty(baseAddress))
    {
        client.BaseAddress = new Uri(baseAddress);
    }
    else
    {
        throw new InvalidOperationException("BaseAddress is not configured.");
    }
});

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ScrapBookAPI"));


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    { 
        // Prevents circular references (quick fix)
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();