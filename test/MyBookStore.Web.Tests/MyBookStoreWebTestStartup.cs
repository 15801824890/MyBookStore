using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace MyBookStore
{
    public class MyBookStoreWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<MyBookStoreWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}