using System.Text.Encodings.Web;
using System.Text.Unicode;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;

using AutoMapper;

using Newtonsoft.Json;

using deech.me.web.middleware;
using deech.me.data.context;
using deech.me.logic.abstractions;
using deech.me.logic.mapper;
using deech.me.logic.services;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace deech.me.web
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
            var mappingConfig = new MapperConfiguration(config => { config.AddProfile(new MappingProfile()); });

            services.Configure<WebEncoderOptions>(options => new TextEncoderSettings(UnicodeRanges.All));
            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddTransient(typeof(IReadDataService<>), typeof(ReadDataService<>));
            services.AddTransient(typeof(IWriteDataService<>), typeof(ReadWriteDataService<>));

            services.AddDbContext<DeechMeDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevelopersConnection"), b => b.MigrationsAssembly("deech.me.web")));

            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<DeechMeDataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("JwtSettings", options))
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));

            services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/build";
                });

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                          ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("logs/deech.me.{Date}.log");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseLoggingMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
