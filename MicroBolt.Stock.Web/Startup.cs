using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroBolt.Stock.Data.Contracts.Models;
using MicroBolt.Stock.IoC.MapperProfiles;
using AutoMapper;
using System.Reflection;
using MicroBolt.Stock.Services.Contracts;
using MicroBolt.Stock.Data.Contracts.Repositories;
using MicroBolt.Stock.Services;
using MicroBolt.Stock.Data;
using MicroBolt.Stock.Data.Contracts;

namespace MicroBolt.Stock.Web
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
            services.AddAutoMapper(typeof(BoltProfile).GetTypeInfo().Assembly);

            services.AddMvc();
            services.Configure<Settings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddTransient<IStoreContext, StoreContext>();
            services.AddTransient<IBoltRepository, BoltRepository>();
            services.AddTransient<IBoltService, BoltService>();
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
