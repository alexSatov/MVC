using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Task1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseMiddleware<RequestTimeMiddleware>();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Start\n");

                var stopwatch = new Stopwatch();

                stopwatch.Start();

                var milliseconds = new Random().Next(1, 5) * 1000;

                await Task.Delay(milliseconds);
                stopwatch.Stop();
                await context.Response.WriteAsync($"End: {stopwatch.ElapsedMilliseconds}");
            });

            app.UseStaticFiles();

            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
        }
    }
}