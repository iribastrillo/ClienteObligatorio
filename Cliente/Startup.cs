using AppLayer.Interfaces;
using AppLayer.UseCases;
using DataLayer.EF;
using DataLayer.EF.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Cliente
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
            services.AddControllersWithViews();
            services.AddSession();

            services.AddDbContext<ClientContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("production")));

            services.AddScoped<IRepositoryUser, UserRepository>();
            services.AddScoped<IRepositoryRoles, RolesRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IListAll, UCListRol>();
            services.AddScoped<ILogin, UCLogin>();
            services.AddScoped<ISignUp, UCSignUp>();
            services.AddScoped<IAssignDefault, UCAssignDefaultRole>();
            services.AddScoped<ICheck, UCCheck>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Index}/{id?}");
            });
        }
    }
}
