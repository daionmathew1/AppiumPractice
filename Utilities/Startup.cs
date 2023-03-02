using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace appiumpractice.Utilities
{

    public static class Startup
    {
       
        //static string file = "/Users/mathew.daion/Projects/appiumpractice/appiumpractice/ConfigFiles/appsettingsHrms.json";
        private static IConfiguration ConfigurePlatform() =>
            new ConfigurationBuilder()
            .AddJsonFile("/Users/mathew.daion/Projects/appiumpractice/appiumpractice/ConfigFiles/appsettingsHrms.json") //{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.
            .Build();

        public static string ReadFromAppSettings(string value) => ConfigurePlatform().GetSection(value).Value;
    }




    //public  class Startup

    //{
    //    private static string _applicationPath = string.Empty;
    //    private static string _contentRootPath = string.Empty;
    //    public IConfigurationRoot Configuration { get; set; }
    //    public Startup(IHostingEnvironment env)
    //    {
    //        _applicationPath = env.WebRootPath;
    //        _contentRootPath = env.ContentRootPath;
    //        // Setup configuration sources.

    //        var builder = new ConfigurationBuilder()
    //            .SetBasePath(_contentRootPath)
    //            .AddJsonFile("appsettings.json")
    //            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

    //        if (env.IsDevelopment())
    //        {
    //            // This reads the configuration keys from the secret store.
    //            // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
    //            builder.AddUserSecrets();
    //        }

    //        builder.AddEnvironmentVariables();
    //        Configuration = builder.Build();
    //    }
    //    private string GetXmlCommentsPath()
    //    {
    //        var app = PlatformServices.Default.Application;
    //        return System.IO.Path.Combine(app.ApplicationBasePath, "Quanta.API.xml");
    //    }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        var pathToDoc = GetXmlCommentsPath();


    //        services.AddDbContext<QuantaContext>(options =>
    //            options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"],
    //            b => b.MigrationsAssembly("Quanta.API")));

    //        //Swagger
    //        services.AddSwaggerGen();
    //        services.ConfigureSwaggerGen(options =>
    //        {
    //            options.SingleApiVersion(new Info
    //            {
    //                Version = "v1",
    //                Title = "Project Quanta API",
    //                Description = "Quant.API",
    //                TermsOfService = "None"
    //            });
    //            options.IncludeXmlComments(pathToDoc);
    //            options.DescribeAllEnumsAsStrings();
    //        });

    //        // Repositories
    //        services.AddScoped<ICheckListRepository, CheckListRepository>();
    //        services.AddScoped<ICheckListItemRepository, CheckListItemRepository>();
    //        services.AddScoped<IClientRepository, ClientRepository>();
    //        services.AddScoped<IDocumentRepository, DocumentRepository>();
    //        services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
    //        services.AddScoped<IProjectRepository, ProjectRepository>();
    //        services.AddScoped<IProtocolRepository, ProtocolRepository>();
    //        services.AddScoped<IReviewRecordRepository, ReviewRecordRepository>();
    //        services.AddScoped<IReviewSetRepository, ReviewSetRepository>();
    //        services.AddScoped<ISiteRepository, SiteRepository>();

    //        // Automapper Configuration
    //        AutoMapperConfiguration.Configure();

    //        // Enable Cors
    //        services.AddCors();

    //        // Add MVC services to the services container.
    //        services.AddMvc()
    //            .AddJsonOptions(opts =>
    //            {
    //                // Force Camel Case to JSON
    //                opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    //            });
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app)
    //    {
    //        app.UseStaticFiles();
    //        // Add MVC to the request pipeline.
    //        app.UseCors(builder =>
    //            builder.AllowAnyOrigin()
    //            .AllowAnyHeader()
    //            .AllowAnyMethod());

    //        app.UseExceptionHandler(
    //          builder =>
    //          {
    //              builder.Run(
    //                async context =>
    //                {
    //                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

    //                    var error = context.Features.Get<IExceptionHandlerFeature>();
    //                    if (error != null)
    //                    {
    //                        context.Response.AddApplicationError(error.Error.Message);
    //                        await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
    //                    }
    //                });
    //          });

    //        app.UseMvc(routes =>
    //        {
    //            routes.MapRoute(
    //                name: "default",
    //                template: "{controller=Home}/{action=Index}/{id?}");

    //            // Uncomment the following line to add a route for porting Web API 2 controllers.
    //            //routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
    //        });


    //        //Ensure DB is created, and latest migration applied. Then seed.
    //        using (var serviceScope = app.ApplicationServices
    //          .GetRequiredService<IServiceScopeFactory>()
    //          .CreateScope())
    //        {
    //            QuantaContext dbContext = serviceScope.ServiceProvider.GetService<QuantaContext>();
    //            dbContext.Database.Migrate();
    //            QuantaDbInitializer.Initialize(dbContext);
    //        }


    //        app.UseSwagger();
    //        app.UseSwaggerUi();


    //    }
    //}

}

