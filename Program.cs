using Intex2Group22.Controllers;
using Intex2Group22.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Intex2Group22.Areas.Identity.Data;
using Microsoft.VisualBasic;
using Intex2Group22.Core;
using Intex2Group22.Core.Repositories;
using Intex2Group22.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.ML.OnnxRuntime;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Build.Evaluation;
using Microsoft.Extensions.Options;
using static Intex2Group22.Controllers.AppSettingsConnection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<intexmummiesContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);

});

builder.Services.AddControllersWithViews();



builder.Services.AddAuthentication();


#region Authorization

AddAuthorizationPolicies(builder.Services);

#endregion

AddScoped();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookie.SecurePolicy = CookieSecurePolicy.Always;
    
});

builder.Services.AddSingleton<InferenceSession>(
    new InferenceSession("wwwroot/decisiontree-classifier.onnx")
);

//THE MASTER

//Password strength requirements
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 9;
    options.Password.RequiredUniqueChars = 1;
});



builder.Configuration.AddUserSecrets<Project>();









# region Sekreto
//var config = new ConfigurationBuilder()
//    .AddUserSecrets<Program>()
//    .Build();
//Console.WriteLine($"Hello, {config["Name"]}");

# endregion


var app = builder.Build();

//var secrets = app.Configuration.GetSection("ConnectionStrings").GetChildren();
//var appSettings = app.Configuration.GetSection("AppSettings");

//foreach (var secret in secrets)
//{
//    appSettings[secret.Key] = secret.Value;
//}

//app.MapGet("/", () =>
//{
//    var mySettings = app.Services.GetRequiredService<IOptions<MySettings>>().Value;

//    return Results.Text($"Connection string: {mySettings.ConnectionStrings.DefaultConnection}");
//});




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{

    app.UseExceptionHandler("/Home/Error");
    // enable hsts
    app.UseHsts();
}


app.UseMiddleware<CspMiddleware>();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

//app.UseIdentityServer();
app.MapRazorPages();

app.Run();


void AddAuthorizationPolicies(IServiceCollection services)
{

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(RoleConstants.Policies.RequireAdmin, policy => policy.RequireRole(RoleConstants.Roles.Administrator));
       
    });
}

void AddScoped()
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}
