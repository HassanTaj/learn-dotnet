using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateManager.EF.Context;
using RealEstateManager.EF.Repositories;
using RealEstateManager.Graph.Mutations;
using RealEstateManager.Graph.Queries;
using RealEstateManager.Graph.Schemas;
using RealEstateManager.Graph.Types;

namespace RealEstateManager {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
             
            services.AddDbContext<RealEstateContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("RealEstateCon")));

            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyInputType>();
            services.AddSingleton<PropertyMutation>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyType>();
            services.AddSingleton<PaymentType>();
            // register schemas
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RealEstateSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            // enable graphi ql 
            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
