using EmailService.Configuration;
using EmailService.EmailHelper;
using EmailService.Interfaces;
using Entities;
using Entities.Configuration;
using Entities.Factory;
using Entities.Mappers;
using Entities.Model;
using Entities.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieAPI;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<UserModel, IdentityRole>(options => {
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;

    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options => {
        options.Conventions.AddPageRoute("/LoginLogout/Login", "/Login");
        options.Conventions.AddPageRoute("/LoginLogout/Logout", "/Logout");
        options.Conventions.AddPageRoute("/LoginLogout/LoginTwoFactorAuthentication", "TwoFactorAuthentication");
    });
builder.Services.AddControllers();


builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Login");
builder.Services.AddScoped<IUserClaimsPrincipalFactory<UserModel>, CustomClaimsFactory>();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromMinutes(2));

var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddSingleton<ICreateMessage, EmailCreator>();
builder.Services.AddSingleton<ISmtpSender, EmailSmtpSender>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MigrateDatabase();

app.Run();
