using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VirtualTrading.API.Repository;
using VirtualTrading.Interface;
using Microsoft.EntityFrameworkCore;
using VirtualTrading.DAL.Models;
using AutoMapper;
using JWTAuthentication.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace VirtualTrading.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
            services.AddDbContext<virtualTraderContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IStockPriceRepository, StockPriceRepository>();
            services.AddTransient<IOrderHistory, OrderHistoryRepository>();
            services.AddTransient<IMyAssest, MyAssestRepository>();
            services.AddTransient<IBuySaleStock, BuySaleStockRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:50392",
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //});
            //------------------------------
            // For Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            //------------------------------
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            //app.UseCors(MyAllowSpecificOrigins);
            //app.UseCors(options => options.AllowAnyOrigin());
            // app.UseCors(
            //    options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            //);
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader());
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
