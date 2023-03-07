using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Respawn;
using System.Text;

namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToMemoryTesting
    {
        private static WebApplicationFactory<Program> _factory = null!;
        private static IConfiguration _configuration = null!;
        private static IServiceScopeFactory _scopeFactory = null!;
        private static string? _currentUserId;
        private static Checkpoint _checkpoint = null!;
        private string BaseUrl = "/api";
        public ToMemoryTesting()
        {

            _factory = new InMemoryApplicationFactory() { CurrentUser = new TestUserLogined(1, Common.Enum.LoanRole.Admin) };

            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
            _configuration = _factory.Services.GetRequiredService<IConfiguration>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };
        }


        public async Task<HttpResponseMessage> CallPostApi<TRequest>(TRequest request, string url)
        {
            using var client = _factory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BaseUrl + url, content);
            return response;
        }

        //public async Task<HttpResponseMessage> HttpClientPostMethod<T>(T vm, string url)
        //{
        //    //CreateClient
        //    using var client = _factory.CreateClient();
        //    var json = JsonConvert.SerializeObject(vm);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync($"{BaseUrl}create", content);
        //    return await client.GetAsync(url);
        //}

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }

        public async Task<Supporter> WithMockSupporter()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            if (!context.Supporters.Any())
            {
                var domainServiceSupporter = scope.ServiceProvider.GetRequiredService<ISupporterDomainService>();

                var admin = await context.Administrators.FirstAsync(m => m.Id == 1);

                var supporter = admin.DefineNewSupporter("0123456987", "09121236548", domainServiceSupporter);

                context.Supporters.Add(supporter);

                await context.SaveChangesAsync();

                return supporter;
            }
            else
            {
                return await context.Supporters.FirstOrDefaultAsync();
            }

        }

        public async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
       where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public T GetRequiredService<T>()
        {
            using var scope = _scopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }
        public void DetachAllEntities()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();

            var changedEntriesCopy = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

    }
}