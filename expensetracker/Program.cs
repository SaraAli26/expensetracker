using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using expensetracker.Data;
using expensetracker.Services;
using expensetracker.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("expensetrackerIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'expensetrackerIdentityContextConnection' not found.");

builder.Services.AddDbContext<ExpensetrackerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ExpensetrackerContext>();

// Add services to the container.
builder.Services.AddTransient<IDateService,DataService>();
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
