using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Srikaran.ARFlights.Data.Writer;
using Srikaran.ARFlights.Service.Commands;
using Srikaran.ARFlights.Service.Queries;

namespace Srikaran.ARFlights.Web
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
            services.AddMvc();

            // Database settings for Data writer
            services.AddDbContext<FlightsDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));

            // DI configuration
            services.Add(new ServiceDescriptor(typeof(ICommandsService), typeof(CommandsService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IQueriesService), typeof(QueriesService), ServiceLifetime.Transient));

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<FlightsDBContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("myconn"));

            // Queries service
            services.AddScoped<IQueriesService>(c => new QueriesService(builder));
            // Command service
            services.AddScoped<ICommandsService>(c => new CommandsService(builder));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

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

            UpdateDatabase(app);
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FlightsDBContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
