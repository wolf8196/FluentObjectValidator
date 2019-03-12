using BooleanResultValidationApp.Middleware;
using BooleanResultValidationApp.Services;
using BooleanResultValidationApp.Validation;
using FluentObjectValidator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoAppNetCore.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IValidator, BooleanResultValidator>()
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