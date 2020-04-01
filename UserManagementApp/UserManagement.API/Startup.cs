using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserManagement.Business;
using UserManagement.Business.Mappings;
using UserManagement.DataAccess;

namespace UserManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (Environment.IsDevelopment())
            {
                services.AddMvc(opts => opts.Filters.Add(new AllowAnonymousFilter()));
            }
            else
            {
                services
                    .AddMvc(option => option.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            }
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "UserManagement API",
                    Description = "User Management API with ASP.NET Core 3.1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Dotnet Detail",
                        Email = "dommalapati.chowdary@gmail.com"
                    }
                });

            });

            services.Configure<DataContextConfiguration>(Configuration.GetSection("ConnectionStrings"))
            .AddSingleton<IDataContextFactory, DataContextFactory>()
            .AddSingleton<IDataContext, DataContext>()
            .AddSingleton<ILoggingWork, LoggingWork>()
            .AddSingleton<IReportingWork, ReportingWork>()
            .AddSingleton<IStory, Story>()
            .AddSingleton(typeof(IMapper), AutoMapperConfiguration.Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserManagement API V1"));
        }
    }
}
