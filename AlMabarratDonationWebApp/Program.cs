using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Core.Repositories.Base;
using AlMabarratDonationWebApp.Infrastructure.Data;
using AlMabarratDonationWebApp.Infrastructure.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Repositories.Base;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using AlMabarratDonationWebApp.Application.Services;
using AlMabarratDonationWebApp.Application.Profiles;
using AlMabarratDonationWebApp.Application.MappingProfiles;
using AlMabarratDonationWebApp.Core.Services;
using AlMabarratDonationWebApp.Service.Services;
using AlMabarratDonationWebApp.Service.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Configuration
// ======================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

// ======================
// DbContexts
// ======================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// ======================
// Identity Configuration (use ApplicationDbContext)
// ======================
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// ======================
// Repositories
// ======================
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ISponsorshipRequestRepository, SponsorshipRequestRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IOrphanRepository, OrphanRepository>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();



// ======================
// Services
// ======================
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ISponsorshipRequestService, SponsorshipRequestService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<IOrphanService, OrphanService>();



// ======================
// AutoMapper
// ======================
builder.Services.AddAutoMapper(typeof(DonationProfile));
builder.Services.AddAutoMapper(typeof(DonorProfile));
builder.Services.AddAutoMapper(typeof(OrphanProfile));
builder.Services.AddAutoMapper(typeof(StaffProfile));

// ======================
// Misc Services
// ======================
builder.Services.AddTransient<IEmailSender, DummyEmailSender>();
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// ======================
// Build and Middleware
// ======================
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == 401)
    {
        response.Redirect("/Identity/Account/Login");
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


// ======================
// Seeding Admin + Roles
// ======================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var identityContext = services.GetRequiredService<ApplicationDbContext>();
    identityContext.Database.Migrate();

    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await SeedRolesAsync(roleManager);
    await SeedAdminUserAsync(userManager, roleManager);
}

async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
{
    string[] roles = { "Admin", "Donor", "Staff" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

async Task SeedAdminUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
{
    var adminEmail = "admin@domain.com";
    var adminPassword = "Admin@123";

    var user = await userManager.FindByEmailAsync(adminEmail);
    if (user == null)
    {
        user = new AppUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "Admin User",
            UserType = "Admin",
            Address = "123 Admin Street",
            City = "Beirut",
            Country = "Lebanon",
            PostalCode = "0000"
        };

        var result = await userManager.CreateAsync(user, adminPassword);
        if (result.Succeeded)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirm = await userManager.ConfirmEmailAsync(user, token);

            if (confirm.Succeeded)
            {
                await userManager.UpdateAsync(user);
                await userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                throw new Exception("Email confirmation failed: " + string.Join(", ", confirm.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            throw new Exception("Admin creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}

app.Run();
