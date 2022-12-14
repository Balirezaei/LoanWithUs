using System;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoanWithUs.IntegrationTest.Utility
{
    internal class InMemoryApplicationFactory : WebApplicationFactory<Program>
    {
        public InMemoryApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureAppConfiguration(configurationBuilder =>
{
    var integrationConfig = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    configurationBuilder.AddConfiguration(integrationConfig);
});

            builder.UseEnvironment("IntegrationTestAuthorized").ConfigureServices((builder, services) =>
            {
                var Configuration = builder.Configuration;

                //services.AddScoped(provider => CurrentUser);
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

                var app = services.BuildServiceProvider();
                using (var scope = app.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<LoanWithUsContext>();
                    db.Database.EnsureDeleted();
                    // db.Database.EnsureCreated();
                    //  db.InitializeTestDatabaseInMemory();
                }
            });

        }
    }

}
