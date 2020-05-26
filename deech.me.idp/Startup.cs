using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;

using deech.me.idp.data;
using deech.me.idp.etc;
using Microsoft.AspNetCore.Identity;

namespace deech.me.idp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddControllersWithViews();
            services.AddDbContext<DeechIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevelopersConnection"),
                 sql => sql.MigrationsAssembly(migrationsAssembly)));

            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<DeechIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                               builder.UseSqlServer(Configuration.GetConnectionString("DevelopersConnection"),
                                   sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(Configuration.GetConnectionString("DevelopersConnection"),
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeDatabase(app);

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();

            if (!context.Clients.Any())
            {
                Config.Clients.ToList().ForEach(c => context.Clients.Add(c.ToEntity()));
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                Config.Ids.ToList().ForEach(i => context.IdentityResources.Add(i.ToEntity()));
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                Config.Apis.ToList().ForEach(a => context.ApiResources.Add(a.ToEntity()));
                context.SaveChanges();
            }
        }
    }
}
