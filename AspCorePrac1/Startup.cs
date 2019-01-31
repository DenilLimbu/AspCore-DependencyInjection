using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCorePrac1.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspCorePrac1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


                





            //ASP.NET Core services can be configured with the following lifetimes:

            //Transient: Transient lifetime services are created each time they're requested. This lifetime works best for lightweight, stateless services.

            //Scoped: Scoped lifetime services are created once per request.
            //Scoped objects are the same within a request, but different across different requests

            //Singleton lifetime services are created the first time they're requested (or when ConfigureServices is run and an instance 
            //is specified with the service registration). Every subsequent request uses the same instance. If the app requires singleton behavior,
            //allowing the service container to manage the service's lifetime is recommended. Don't implement the singleton design pattern and 
            //provide user code to manage the object's lifetime in the class.

            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));

            // OperationService depends on each of the other Operation types.
      
            services.AddTransient<OperationService, OperationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
