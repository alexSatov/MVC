using StudentsMVC.Models;
using StudentsMVC.Services;
using StudentsMVC.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsMVC.Configs;

namespace StudentsMVC
{
    public class Startup
    {
        private const string connectionString =
            "Server=(localdb)\\mssqllocaldb;" +
            "Database=StudentsDb;" +
            "Trusted_Connection=True;" +
            "MultipleActiveResultSets=True;";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IdModel>();
            services.AddTransient<Student>();
            services.AddSingleton<StudentService>();

            services.Configure<Host>(Configuration.GetSection("Host"));

            services.AddDbContext<StudentContext>(opt => opt.UseSqlServer(connectionString));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
        }
    }
}