using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OnlineVoting.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    // Configure ASP.NET Core Identity
builder.Services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

 void Configure(IApplicationBuilder app, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
{
    // Other app configurations

    // Create roles
    var roles = new[] { "Admin", "Voter" };
    foreach (var role in roles)
    {
        if (!roleManager.RoleExistsAsync(role).Result)
        {
            var identityRole = new IdentityRole(role);
            roleManager.CreateAsync(identityRole).Wait();
        }
    }

    // Assign roles to users
    var adminUser = userManager.FindByNameAsync("admin").Result;
    userManager.AddToRoleAsync(adminUser, "Admin").Wait();

    // Other middleware configurations
}

// Register repositories
builder.Services.AddScoped<IVoteRepository, VoteRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IElectionRepository, ElectionRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
    // Add other repositories

    // Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/*var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "user",
    pattern: "Users/{action=Index}/{id?}",
    defaults: new { controller = "User" });

app.MapControllerRoute(
    name: "election",
    pattern: "Elections/{action=Index}/{id?}",
    defaults: new { controller = "Election" });

app.MapControllerRoute(
    name: "vote",
    pattern: "Votes/{action=Index}/{id?}",
    defaults: new { controller = "Vote" });
app.MapControllerRoute(
    name: "candidate",
    pattern: "Candidates/{action=Index}/{id?}",
    defaults: new { controller = "Candidate" });*/

app.Run();
