using Microsoft.EntityFrameworkCore;
using ScrapBook.Components;
using ScrapBook.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();  
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Add DbContext for SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<JourneyRepository>();
builder.Services.AddScoped<JourneyImageRepository>();
builder.Services.AddScoped<IJourneyRepository, JourneyRepository>();
builder.Services.AddScoped<IJourneyImageRepository, JourneyImageRepository>();

// Register HttpClient (for API communication) - Remove this for Blazor Web App, it's unnecessary

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    { 
        // Prevents circular references (quick fix)
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

// Configure routing
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();