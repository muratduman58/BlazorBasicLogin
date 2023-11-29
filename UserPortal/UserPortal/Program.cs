using UserPortal.Business.Api;
using UserPortal.Business.Login;
using UserPortal.Interfaces.Api;
using UserPortal.Interfaces.Login;
using MudBlazor.Services;
using UserPortal.Interfaces.Cache;
using UserPortal.Business.Cache;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using UserPortal.Interfaces.User;
using UserPortal.Business.User;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ILogin, LoginManager>();
builder.Services.AddScoped<IApiManager, ApiManager>();
builder.Services.AddScoped<ICache,CacheManager>();
builder.Services.AddScoped<IUser,UserManager>();
builder.Services.AddMudServices();
builder.Services.AddMemoryCache();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
