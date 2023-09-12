using AutoMapper;
using LandonApi.Filters;
using LandonApi.Infrastructure;
using LandonApi.Models;
using LandonApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LandonApi {
    public class Startup {
        private readonly int? _httpsPort;
        private readonly IHostingEnvironment _env;
        public Startup(IConfiguration configuration, IHostingEnvironment env) {
            Configuration = configuration;
            _env = env;

            // get the https port (only in developement)
            if (_env.IsDevelopment()) {
                var launcSettingsJson = new ConfigurationBuilder()
                    .SetBasePath(_env.ContentRootPath)
                    .AddJsonFile("Properties\\launchsettings.json")
                    .Build();
                _httpsPort = launcSettingsJson.GetValue<int>("iisSettings:iisExpress:sslPort");
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            // config autoMapper
            // method 1
            //var mappingConf = new MapperConfiguration(mc => {
            //    mc.AddProfile(new MappingProfile());
            //});
            //IMapper mapper = mappingConf.CreateMapper();
            //services.AddSingleton(mapper);

            // method 2
            services.AddAutoMapper(opts=> opts.AddProfile<MappingProfile>());
            Mapper.Initialize(cfg => {
                cfg.AddProfile(new MappingProfile());
            });

            services.AddMvc(opt => {
                // config ion output formatter
                var jsonFormatter = opt.OutputFormatters.OfType<JsonOutputFormatter>().Single();
                opt.OutputFormatters.Remove(jsonFormatter);
                opt.OutputFormatters.Add(new IonOutputFormatter(jsonFormatter));

                // exception filter
                opt.Filters.Add(typeof(JsonExceptionFilter));

                // Transport Security
                // require https for all controllers
                // to increase this security further install nwebsec.aspnetcore.middleware
                opt.SslPort = _httpsPort;
                opt.Filters.Add(typeof(RequireHttpsAttribute));

                // adding result filter
                opt.Filters.Add(typeof(LinkRewritingFilter));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(opts => {
                // These should be the defaults, but we can be explicit:
                opts.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                opts.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                opts.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            });


            services.AddRouting(opt => opt.LowercaseUrls = true);

            // config api media type versioning 
            services.AddApiVersioning(opt => {
                opt.ApiVersionReader = new MediaTypeApiVersionReader();
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);
            });

            // api behaviour options
            services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = context => {
                    var errorResponse = new ApiError(context.ModelState);
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            // configure hotel dump data from appsettings
            services.Configure<HotelInfo>(Configuration.GetSection("Info"));
            services.Configure<PagingOptions>(Configuration.GetSection("DefaultPagingOptions"));
            services.Configure<HotelOptions>(Configuration);
            // using in memory database
            services.AddDbContext<HotelApiContext>(opt => opt.UseInMemoryDatabase("LondanHotelApiDB"));

            // repositories or services
            services.AddScoped<IRoomService, DefaultRoomService>();
            services.AddScoped<IOpeningService, DefaultOpeningService>();
            services.AddScoped<IBookingService, DefaultBookingService>();
            services.AddScoped<IDateLogicService, DefaultDateLogicService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // increase transpoart security nwebsec.aspnetcore.middleware
            app.UseHsts(opt => {
                opt.MaxAge(days: 180);
                opt.IncludeSubdomains();
                opt.Preload(); // assume that the site uses hsts if the site is submitted to a common list of hsts websites 
            });

            app.UseMvc();

            // add some test data in development to the database
            if (_env.IsDevelopment()) {
                using (var serviceScope = app.ApplicationServices.CreateScope()) {
                    var ctx = serviceScope.ServiceProvider.GetRequiredService<HotelApiContext>();
                    AddTestData(ctx);
                }
            }
        }
        // add test entities to database
        private static void AddTestData(HotelApiContext ctx) {
            ctx.Rooms.Add(new RoomEntity {
                Id = Guid.Parse("a27ed740-49f2-4d94-b1e6-fe84baacef9c"),
                Name = "Oxford Suite",
                Rate = 10119
            });

            ctx.Rooms.Add(new RoomEntity {
                Id = Guid.Parse("2414e77f-6a30-4c78-80a5-928effd01c3c"),
                Name = "Driscoll Suite",
                Rate = 23959
            });

            ctx.SaveChanges();
        }
    }
}
