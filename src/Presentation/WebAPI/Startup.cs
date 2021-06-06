using AutoMapper;
using Business.AutoMapper;
using Business.Constant;
using Business.DataServices;
using Business.Services;
using Data;
using Data.Infrastructure.Email;
using Data.Infrastructure.JwtToken;
using Data.Infrastructure.PasswordHasher;
using Data.Infrastructure.Utility;
using DTO.Configuration;
using Entity;
using Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace WebAPI1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });
            services.AddSpaStaticFiles(configuration => 
            { 
                configuration.RootPath = "client-app"; 
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI1", Version = "v1" });
            });

            #region appsetting
            var appSettingsSection = Configuration.GetSection("JWT");
            services.Configure<JWT>(appSettingsSection);
            var emailAccountSettingsSection = Configuration.GetSection("EmailAccount");
            services.Configure<EmailAccount>(emailAccountSettingsSection);


            // services.AddSingleton(Configuration.GetSection("AppConstants").Get<AppConstants>());// no need to use IOption

            #endregion
            services.AddDbContext<AppDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), settings => settings.EnableRetryOnFailure().CommandTimeout(120)));
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21))));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });

            // configure jwt authentication
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


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSpaStaticFiles();
            app.UseSpa(builder =>
            {
                
                if (env.IsDevelopment())
                {
                    builder.Options.SourcePath = "client-app/";
                    builder.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                    
                }
                else
                {
                    builder.Options.SourcePath = "client-app/dist/";
                }
            });
        }
    }
}
