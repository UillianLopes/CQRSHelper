using CQRSHelper.Mediator.Extensions;
using CQRSHelper.Test.Handlers;
using CQRSHelper.Test.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSHelper.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediator(options => options
                .AddHandlersOnAssemblyOf<UserHanlder>()
                .AddValidatorsOnAssemblyOf<CreateUserValidator>());

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
