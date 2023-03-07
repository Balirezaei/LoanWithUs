using System;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility.Authorization;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    internal class InMemoryApplicationFactory : WebApplicationFactory<Program>
    {
        public InMemoryApplicationFactory()
        {
        }
        public TestUserLogined CurrentUser { get; set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.UseEnvironment("IntegrationTest").ConfigureAppConfiguration(configurationBuilder =>
{
    var integrationConfig = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    configurationBuilder.AddConfiguration(integrationConfig);
});

            builder.UseEnvironment("IntegrationTest").ConfigureServices((builder, services) =>
            {
                var Configuration = builder.Configuration;

                services.AddScoped(provider => CurrentUser);
                //services.AddDbContext<ORMSContext>(options =>
                //{
                //    options.UseInMemoryDatabase("InMemoryDbForTesting");
                //});

                //Mock 
                //services.AddScoped<IMessagePublisher>(provider => { return Substitute.For<IMessagePublisher>(); });
                //services.AddScoped<ILogManagement>(provider => { return Substitute.For<ILogManagement>(); });
                //services.AddScoped<IErrorHandling>(provider => { return Substitute.For<IErrorHandling>(); });

                //services.AddFrameworkServices(configuration);
                //services.AddCommandHandlerServices();
                //services.AddQueryHandlerServices();

                //services.AddAuthentication("BmiSSO")
                //    .AddScheme<BasicTestAuthenticationOptions, BasicAuthenticationHandler
                //    >("BmiSSO", options => { });

                //services.AddAuthorization();
                //services.AddScoped<ITokenService, TokenService>();
                //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
                //services.AddAuthentication().AddJwtBearer();

                //services.AddScoped<IErrorHandling>(provider => { return Substitute.For<IErrorHandling>(); });

                //services.AddScoped<CurrentUser>(provider =>
                //{
                //    var currentUser = new CurrentUser();
                //    currentUser.UserId = this.CurrentUser.NationalCode;
                //    currentUser.UserName = this.CurrentUser.UserName;
                //    return currentUser;
                //});

                //services.AddAuthorization(options =>
                //{
                //    //                options.AddPolicy("Over18",policy => policy.Requirements.Add(new Over18Requirement()));
                //});

                //var sp = services.BuildServiceProvider();
                //using (var scope = sp.CreateScope())
                //{
                //    var scopedServices = scope.ServiceProvider;
                //    var db = scopedServices.GetRequiredService<LoanWithUsContext>();
                //    db.Database.EnsureDeleted();
                //    db.Database.EnsureCreated();
                //    db.InitializeTestDatabaseInMemory();
                //}




                //var _contextOptions = new DbContextOptionsBuilder<LoanWithUsContext>()
                //        .UseInMemoryDatabase("LoanWithUsContextTest")
                //        .Options;

                //using var context = new LoanWithUsContext(_contextOptions);

                services
               .Remove<DbContextOptions<LoanWithUsContext>>()
               .AddDbContext<LoanWithUsContext>(options =>
                {
                    options.UseInMemoryDatabase("LoanWithUsContextTest1");

                });


                services
                .AddAuthentication("BmiSSO")
                    .AddScheme<BasicTestAuthenticationOptions, BasicAuthenticationHandler
                    >("BmiSSO", options => { });

                services.AddAuthorization();

                services
           .Remove<UserDataSecurityDate>()
           .AddScoped(provider =>
           {
               //var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
               // string userAgentHeader = httpContext?.Request?.Headers["User-Agent"] ?? "";
               // var authorizationHeader = httpContext?.Request.Headers["Authorization"];
               var userAgent = new UserDataSecurityDate()
               {
                   //BrowserType = (short)BrowserDetection.GetBrowserType(userAgentHeader),
                   IP = "localhost",
                   LocalIp = "localhost",
                   //OsType = (short)OsDetection.GetOsType(userAgentHeader),
                   //SqlTokenInfoKey = sqlToken
                   UserAgent = "IntegrationTestUserAgent"
               };
               return userAgent;
           });




                var app = services.BuildServiceProvider();
                using (var scope = app.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<LoanWithUsContext>();

                    scopedServices.GetRequiredService<LoanWithUsContext>().Database.EnsureCreated();


                    //db.Database.EnsureDeleted();

                    //db.Database.EnsureCreated();
                    //db.Database.Migrate();
                    //  db.InitializeTestDatabaseInMemory();
                }
            });

        }
    }

}
