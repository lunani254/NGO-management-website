using ESSMaterWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<MaterDBContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity with roles
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Enable role-based authorization
    .AddEntityFrameworkStores<MaterDBContext>();

// Configure StripeSettings from appsettings.json
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// Add controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseAuthentication(); // Enable authentication
app.UseAuthorization();

// Map default routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

/*
using ESSMaterWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers; // Used for setting security headers

var builder = WebApplication.CreateBuilder(args);

// *******************************************************
// Configure Database and Developer Exception Page
// *******************************************************
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<MaterDBContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// *******************************************************
// Configure Identity with Enhanced Security Settings
// *******************************************************
// Here, we add role management and further secure the Identity system
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    // Email Confirmation: Consider requiring confirmed emails in production.
    options.SignIn.RequireConfirmedAccount = false; // For production, set to true

    // Password Policy: Enforce complexity to reduce brute force risks.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

    // Lockout Policy: Prevent repeated invalid login attempts.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
})
.AddRoles<IdentityRole>() // Enable role-based authorization.
.AddEntityFrameworkStores<MaterDBContext>();

// *******************************************************
// Configure Controllers and Views
// *******************************************************
builder.Services.AddControllersWithViews();

// *******************************************************
// Configure CORS Policy (Optional, adjust as needed)
// *******************************************************
// This policy restricts which origins can access your API endpoints.
// Uncomment and customize the allowed origins as required.
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policyBuilder =>
    {
        policyBuilder.WithOrigins("https://example.com") // Replace with your allowed origins.
                     .AllowAnyHeader()
                     .AllowAnyMethod();
    });
});

// *******************************************************
// Configure Secure Cookie Settings for Identity
// *******************************************************
// These settings help protect cookies against XSS and ensure they are only sent over HTTPS.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; // Prevent client-side scripts from accessing the cookie.
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure cookies are always transmitted over HTTPS.
    options.Cookie.SameSite = SameSiteMode.Lax; // Adjust SameSite policy (Lax or Strict) based on your needs.
    options.LoginPath = "/Identity/Account/Login"; // Path to the login page.
    options.AccessDeniedPath = "/Identity/Account/AccessDenied"; // Path when access is denied.
    options.SlidingExpiration = true; // Refresh cookie expiration on each request.
});

// *******************************************************
// (Optional) Configure Anti-Forgery Options
// *******************************************************
// ASP.NET Core has built-in CSRF protection for Razor Pages and MVC forms.
// You can customize settings here if needed.
builder.Services.AddAntiforgery(options =>
{
    // For example: options.HeaderName = "X-XSRF-TOKEN";
});

var app = builder.Build();

// *******************************************************
// Configure the HTTP Request Pipeline
// *******************************************************
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // Use a generic error handler to avoid exposing sensitive error details.
    app.UseExceptionHandler("/Home/Error");
    // HSTS: Instructs browsers to use HTTPS only, reducing downgrade attack risks.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// *******************************************************
// Add Authentication Middleware
// *******************************************************
// This middleware must be placed before UseAuthorization so that the user is authenticated
// (i.e., HttpContext.User is set) before the authorization policies are enforced.
app.UseAuthentication(); // <<<-- Added authentication middleware

// *******************************************************
// (Optional) Use CORS Policy
// *******************************************************
// Uncomment the following line if your application requires CORS.
 // app.UseCors("DefaultCorsPolicy");

// *******************************************************
// Add Security Headers Middleware
// *******************************************************
// This custom middleware adds HTTP headers that enhance security (e.g., mitigating XSS and clickjacking).
app.Use(async (context, next) =>
{
    // Prevent browsers from MIME-sniffing the response away from the declared content-type.
    context.Response.Headers[HeaderNames.XContentTypeOptions] = "nosniff";
    
    // Enable the XSS Protection filter built into most browsers.
    context.Response.Headers[HeaderNames.XXssProtection] = "1; mode=block";
    
    // Content-Security-Policy: Restrict sources for content; adjust as needed for your app.
    context.Response.Headers["Content-Security-Policy"] = "default-src 'self';";
    
    // Referrer-Policy: Control the amount of referrer information sent.
    context.Response.Headers["Referrer-Policy"] = "no-referrer";
    
    await next();
});

// *******************************************************
// Add Authorization Middleware
// *******************************************************
// This middleware evaluates the user's permissions to access requested resources.
app.UseAuthorization();

// *******************************************************
// Define Routing for Controllers and Razor Pages
// *******************************************************
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

 */