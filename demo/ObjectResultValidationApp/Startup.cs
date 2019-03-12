using FluentObjectValidator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ObjectResultValidationApp;
using ObjectResultValidationApp.Services;
using ObjectResultValidationApp.Validation;

namespace DemoAppNetCore.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IValidator<ValidationError>, ObjectResultValidator>()
                .AddSingleton<DemoService>()
                .AddSingleton<ExceptionHandlingMiddleware>()
                .AddMvcCore();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app
                .UseMiddleware<ExceptionHandlingMiddleware>()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseMvc();
        }
    }
}