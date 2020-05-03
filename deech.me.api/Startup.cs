using System.Text.Encodings.Web;
using System.Text.Unicode;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;

using deech.me.api.middleware;
using deech.me.data.context;
using deech.me.logic.abstractions;
using deech.me.logic.services;

using Newtonsoft.Json;

namespace deech.me.api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<WebEncoderOptions>(options => new TextEncoderSettings(UnicodeRanges.All));
            services.AddTransient(typeof(IReadDataService<>), typeof(ReadDataService<>));
            services.AddDbContext<DeechMeDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevelopersConnection"), b => b.MigrationsAssembly("deech.me.api")));
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000",
                                                          "https://localhost:3000")
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                  });
            });
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
