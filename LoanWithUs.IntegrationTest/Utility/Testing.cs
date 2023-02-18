using LoanWithUs.Domain;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using Respawn;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace LoanWithUs.IntegrationTest.Utility
{
    public partial class ToSqlTesting
    {
        private static WebApplicationFactory<Program> _factory = null!;
        private static IConfiguration _configuration = null!;
        private static IServiceScopeFactory _scopeFactory = null!;
        private static string? _currentUserId;
        private static Checkpoint _checkpoint = null!;

        public ToSqlTesting()
        {
            _factory = new SqlWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
            _configuration = _factory.Services.GetRequiredService<IConfiguration>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };
        }


        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }

        public async Task<HttpResponseMessage> CallPostApi<TRequest>(TRequest request, string url)
        {
            using var client = _factory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            //var responseText = await response.Content.ReadAsStringAsync();
            //response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            //var authorithyDelegatedCreated = JsonConvert.DeserializeObject<TResponse>(responseText);
            //authorithyDelegatedCreated.Error.Message.Should().Be(MessageResource.AuthorityDelegationExceptionJuniorHasOpenWork);
            return response;
        }

        //public async Task<HttpResponseMessage> CallGetApi<TRequest>(TRequest request, string url)
        //{
        //    using var client = _factory.CreateClient();
        //    var json = JsonConvert.SerializeObject(request);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(url, content);
        //    //var responseText = await response.Content.ReadAsStringAsync();
        //    //response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        //    //var authorithyDelegatedCreated = JsonConvert.DeserializeObject<TResponse>(responseText);
        //    //authorithyDelegatedCreated.Error.Message.Should().Be(MessageResource.AuthorityDelegationExceptionJuniorHasOpenWork);
        //    return response;
        //}

        public string? GetCurrentUserId()
        {
            return _currentUserId;
        }

        public async Task WithDefaultApplicant()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            await context.Applicants.AddAsync(new ApplicantBuilder(context).WithMobileNumber("09381112233").Build());
            await context.SaveChangesAsync();
        }

        public async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("LoanWithUsContext"));

            _currentUserId = null;
        }

        public async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public async Task<int> CountAsync<TEntity>() where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();

            return await context.Set<TEntity>().CountAsync();
        }

        public async Task<UserLogin> WithMockAdminAttempdToLogin()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            var admin = await context.Administrators.FirstAsync(m => m.Id == 1);
            var adminLogin = admin.AddNewAttempdToLogin("IntegrationTest");
            await context.SaveChangesAsync();
            return adminLogin;

        }
        public T GetRequiredService<T>()
        {
            using var scope = _scopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }
    }
}