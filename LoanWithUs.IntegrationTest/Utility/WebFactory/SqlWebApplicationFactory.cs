using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility.Authorization;
using LoanWithUs.Persistense.EF.ContextContainer;
using LoanWithUs.RestApi.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    internal class SqlWebApplicationFactory : WebApplicationFactory<Program>
    {
        public SqlWebApplicationFactory(TestUserLogined currentUser)
        {
            CurrentUser = currentUser;
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

            builder.ConfigureServices((builder, services) =>
            {
                //services
                //    .Remove<ICurrentUserService>()
                //    .AddTransient(provider => Mock.Of<ICurrentUserService>(s =>
                //        s.UserId == GetCurrentUserId()));


                services.AddScoped(provider => CurrentUser);

                services
               .Remove<UserDataSecurityDate>().AddScoped(m =>
               {
                   return new UserDataSecurityDate()
                   {
                       IP = "IntegrationTest",
                       UserAgent = "IntegrationTest",
                       LocalIp = "IntegrationTest",
                   };
               });

                services
            .AddAuthentication("BmiSSO")
                .AddScheme<BasicTestAuthenticationOptions, BasicAuthenticationHandler
                >("BmiSSO", options => { });


                services.AddScoped<ITokenService, TokenService>();

                services
                    .Remove<DbContextOptions<LoanWithUsContext>>()
                    .AddDbContext<LoanWithUsContext>((sp, options) =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("LoanWithUsContext"),
                            builder => builder.MigrationsAssembly(typeof(LoanWithUsContext).Assembly.FullName)));


                var app = services.BuildServiceProvider();

                using (var scope = app.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<LoanWithUsContext>();
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    db.DbDataInitializer();
                }
            });
        }
    }

}
