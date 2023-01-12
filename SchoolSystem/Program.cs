using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SchoolSystem;
using System.Text;
//Pomelo.EntityFrameworkCore.MySql
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Configuration.AddJsonFile("config.json", optional: true, reloadOnChange: true);

var connectionString = builder.Configuration["ConnectionDB"];
builder.Services.AddDbContext<DbApp>(options =>
               options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
                {
                    options.Events.OnRedirectToLogin = async (context) =>
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("Unauthorized"));
                    };
                });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Version = "v1",
        Title = "First API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Dmytro",
            Email = "vodacode.work@gmail.com",
            Url = new Uri("https://vodacode.space")
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();

app.MapFallbackToFile("index.html");

app.Run();
