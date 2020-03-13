using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using UserManagment.UI.Services;

namespace UserManagment.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var apiHost = Configuration
               .GetSection("UsersAPI")
               .GetValue<string>("Host")
               .TrimEnd('/');

            var apiKey = Configuration.GetSection("UsersAPI").GetValue<string>("Key");

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services
                .AddHttpClient<IUsersService, UsersService>(r =>
                {
                    r.BaseAddress = new Uri($"{apiHost}/api/users");
                    r.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
                })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseProxy = false });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
