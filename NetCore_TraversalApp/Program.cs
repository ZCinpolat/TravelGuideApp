using BusinessLayer.Container;
using DataAccessLayer.Concrate;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EntityLayer.Concrate;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using NetCore_TraversalApp.Models;
using NLog.Fluent;
using Serilog;
using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Active to logger 
builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});


//Add project dependencies
DependencyServices.Add(builder.Services);

//identity icin eklendi start
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddMvc(config =>
{
    var p = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(p));
});
builder.Services.AddMvc();
//identity - end


//builder.Services.AddHttpContextAccessor();

// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<Context>();
//builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

//builder.Services.AddScoped<ICustomerAccountProcessDal, EfCustomerAccountProcessDal>();
//builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();


//// Add services to the container.
//builder.Services.AddControllersWithViews();

var app = builder.Build();


//Log  writo to txt Files
var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
var tracePath = Path.Join(path, $"Log_CustomerService_{DateTime.Now.ToString("yyyyMMdd-HHmm")}.txt");
Trace.Listeners.Add(new TextWriterTraceListener(tracePath));
Trace.AutoFlush = true;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//Sistemde olmayan bir url cagrilmask sitenildiginde, bu kismi kaldirmamiz gerekiyor.
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();


//identity icin eklendi - start
app.UseAuthentication();
// - end


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Default}/{action=Index}/{id?}");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
