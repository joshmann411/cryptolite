using cryptolte.Interfaces;
using cryptolte.Models;
using cryptolte.Repositories.SqlRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.HttpOverrides;

namespace cryptolte
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

            services.Configure<ForwardedHeadersOptions>(option =>
            {
                option.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddHttpsRedirection(option =>
            {
                option.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
                option.HttpsPort = 5001;
            });

            services.AddAuthentication(
                CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();


            // services.AddDbContext<AppDbContext>(
            //   options => options.UseSqlServer(Configuration.GetConnectionString("cryptoDBConnection"))
            //);

            string mySqlConnectionStr = Configuration.GetConnectionString("cryptoDBConnection");

            services.AddDbContextPool<AppDbContext>(options => options.UseMySql(
                mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));


            //Enale CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                                                options
                                                .AllowAnyOrigin()
                                                .AllowAnyMethod()
                                                .AllowAnyHeader()
                                                .SetIsOriginAllowedToAllowWildcardSubdomains());
            });

            //permit json serialization
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
            );


            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IContact, SqlContactRepository>();
            services.AddScoped<IPurchase, SqlPurchaseRepository>();
            services.AddScoped<IBilling, SqlBillingRepository>();
            services.AddScoped<IAccount, SqlAccountRepository>();
            services.AddScoped<IAccountType, SqlAccountTypeRepository>();
            services.AddScoped<IClient, SqlClientRepository>();


            //Add Identity
            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 4;

                opt.User.RequireUniqueEmail = true;
                //opt.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //give the application the ability to authenticate jwt tokens
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"])),
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false
                };
            });


            services.AddAuthorization(options =>
            {
                //any user which is a ManagerDevelopers must have: 
                // > a claim Title = Customer
                // > a role: manager
                options.AddPolicy("CustomerRole", md =>
                {
                    md.RequireClaim("claimtitle", "Customer");
                    md.RequireRole("Customer");
                });

                //any user which is a AdminDevelopers must have: 
                // > a claim Title = Admin
                // > a role: Administrator
                options.AddPolicy("AdminRole", ad =>
                {
                    ad.RequireClaim("claimtitle", "Admin");
                    ad.RequireRole("Administrator");
                });
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "cryptolte", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //updates the Request.Scheme with the X-Forwarded-Proto header so that all redirects link
            //generation uses the correct scheme
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
            });

            //configure logging
            loggerFactory.AddFile("Logs/ts-{Date}.txt");

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseForwardedHeaders();
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseForwardedHeaders();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ylem.businessapi v1"));
            }

            
            app.UseHttpsRedirection();
            
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseRouting();

            //app.UseAuthentication();
                
            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
