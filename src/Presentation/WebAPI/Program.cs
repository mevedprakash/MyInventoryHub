using Business.AutoMapper;
using Business.DataServices;
using Business.Services;
using Data;
using Data.Infrastructure;
using Data.Infrastructure.Email;
using Data.Infrastructure.JwtToken;
using Data.Infrastructure.PasswordHasher;
using Data.Infrastructure.Utility;
using DTO.Configuration;
using Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var services = builder.Services;
services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "dist";
});
#region appsetting
var appSettingsSection = builder.Configuration.GetSection("JWT");
services.Configure<JWT>(appSettingsSection);
var emailAccountSettingsSection = builder.Configuration.GetSection("EmailAccount");
services.Configure<EmailAccount>(emailAccountSettingsSection);

var appSettings = appSettingsSection.Get<JWT>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
// services.AddSingleton(Configuration.GetSection("AppConstants").Get<AppConstants>());// no need to use IOption

#endregion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
services.AddDbContext<AppDbContext>(options =>
 //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), settings => settings.EnableRetryOnFailure().CommandTimeout(120)));
 options.UseMySql(connectionString, serverVersion));



services.AddAutoMapper(typeof(AutoMapping));

//register here all the classes and services to provide in dependency injection
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IAuthenticationService, AuthenticationService>();
services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<IJwtService, JwtService>();
services.AddScoped<IEmailQueueService, EmailQueueService>();
services.AddScoped<IEmailSender, EmailSender>();
services.AddScoped<IRandomUtility, RandomUtility>();
services.AddScoped<ICommonService, CommonService>();
services.AddScoped<IBrandService, BrandService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<ISupplyService, SupplyService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IStoreService, StoreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "dist";

});
app.MapControllers();

app.Run();
