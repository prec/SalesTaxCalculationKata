using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SalesTaxCalculationKata.Data;

namespace SalesTaxCalculationKata.Web
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
          services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
          services.AddSingleton(ConfigureMapper());
          services.AddDbContext<KataDbContext>();
        }

        private static IMapper ConfigureMapper()
        {
          var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
          return mappingConfig.CreateMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                  HotModuleReplacement = true, 
                  ConfigFile="webpack.netcore.config.js",
                  HotModuleReplacementClientOptions = new Dictionary<string,string>{
                    {"reload", "true"}
                  }
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            RecreateDatabase(app);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private static void RecreateDatabase(IApplicationBuilder app)
        {
          using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
          {
            var context = serviceScope.ServiceProvider.GetRequiredService<KataDbContext>();
            context.Database.EnsureDeleted();
            context.Database.Migrate();
          }
        }
    }
}
