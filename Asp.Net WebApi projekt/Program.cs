using Asp.Net_WebApi_projekt.Data;
using Asp.Net_WebApi_projekt.ModelBinders;
using Asp.Net_WebApi_projekt.Repositories;
using Asp.Net_WebApi_projekt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IReadClientService, ReadClientService>();
builder.Services.AddScoped<IReadSwimmingPoolService, ReadSwimmingPoolService>();
builder.Services.AddScoped<IWriteSwimmingPoolService, WriteSwimmingPoolService>();
builder.Services.AddScoped<IReadSwimmingTrackService, ReadSwimmingTrackService>();
builder.Services.AddScoped<IReadReservationService, ReadReservationService>();
builder.Services.AddScoped<IWriteReservationService, WriteReservationService>();

builder.Services.AddAuthorization((options) =>
{
    options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

Task.Run(async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        bool x = await roleManager.RoleExistsAsync("Administrator");
        if (!x)
        {
            // first we create Admin role   
            var role = new IdentityRole();
            role.Name = "Administrator";
            await roleManager.CreateAsync(role);

            //Here we create a Admin super user who will maintain the website                   

            var adminConfig = builder.Configuration.GetSection("Administrator");

            var user = new IdentityUser();
            user.UserName = adminConfig.GetValue<string>("UserName");
            user.Email = adminConfig.GetValue<string>("Email");

            string userPWD = adminConfig.GetValue<string>("Password") ?? throw new ArgumentException("Administrator not configured");

            IdentityResult chkUser = await userManager.CreateAsync(user, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                var result1 = await userManager.AddToRoleAsync(user, "Administrator");
            }
        }
    }
        
}).Wait();

app.Run();