﻿using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.IntegrationTest.Utility;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.Persistense.EF.ContextContainer;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Respawn;
using System.Linq.Expressions;
using System.Text;

namespace LoanWithUs.IntegrationTest
{
    public abstract class ToTesting
    {
        private static WebApplicationFactory<Program> _factory;
        public IConfiguration _configuration = null!;
        public IServiceScopeFactory _scopeFactory = null!;
        public TestUserLogined CurrentUser { get; set; }
        public Checkpoint _checkpoint = null!;
        public string BaseUrl = "/api";



        protected ToTesting(WebFactoryType webFactoryType, TestUserLogined currentUser)
        {
            if (webFactoryType == WebFactoryType.SQL)
            {
                _factory = new SqlWebApplicationFactory(currentUser);
            }
            else if (webFactoryType == WebFactoryType.InMemory)
            {
                _factory = new InMemoryApplicationFactory() { CurrentUser = currentUser };
            }
            CurrentUser = currentUser;
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
            _configuration = _factory.Services.GetRequiredService<IConfiguration>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };
        }

        //public virtual async Task<HttpResponseMessage> CallGetApi<TRequest>(TRequest request, string url)
        //{
        //    using var client = _factory.CreateClient();
        //    var json = JsonConvert.SerializeObject(request);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(url, content);
        //    return response;
        //}

        public async Task<HttpResponseMessage> CallGetApi(string url)
        {
            using var client = _factory.CreateClient();

            url = $"{BaseUrl}{url}";
            var response = await client.GetAsync(url);

            //var responseText = await response.Content.ReadAsStringAsync();
            //response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            //var authorithyDelegatedCreated = JsonConvert.DeserializeObject<TResponse>(responseText);
            //authorithyDelegatedCreated.Error.Message.Should().Be(MessageResource.AuthorityDelegationExceptionJuniorHasOpenWork);
            return response;
        }
        public async Task<HttpResponseMessage> CallGetApi<TRequest>(TRequest request, string url)
        {
            using var client = _factory.CreateClient();
            var json = JsonConvert.SerializeObject(request);

            url = $"{BaseUrl}{url}?" + request.ToQueryString();
            var response = await client.GetAsync(url);

            //var responseText = await response.Content.ReadAsStringAsync();
            //response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            //var authorithyDelegatedCreated = JsonConvert.DeserializeObject<TResponse>(responseText);
            //authorithyDelegatedCreated.Error.Message.Should().Be(MessageResource.AuthorityDelegationExceptionJuniorHasOpenWork);
            return response;
        }
        public virtual async Task<List<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includes = null) where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            var query = context.Set<TEntity>().Where(predicate);
            if (includes != null && includes.Any())
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }

        public virtual async Task<HttpResponseMessage> CallPostApi<TRequest>(TRequest request, string url)
        {
            using var client = _factory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BaseUrl + url, content);
            return response;
        }

        public virtual async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
       where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public virtual T GetRequiredService<T>()
        {
            using var scope = _scopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }
        public virtual void DetachAllEntities()
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
        public virtual async Task<LoanWithUsFile> WithMockFile()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            var file = new LoanWithUsFile("/moq", "testFile.jpg", ".jpg", "/moq/testFile.jpg", FileType.UserNationalCard);

            await context.LoanWithUsFiles.AddAsync(file);

            await context.SaveChangesAsync();

            return file;
        }

        public virtual async Task<UserLogin> WithMockAdminAttempdToLogin()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            var admin = await context.Administrators.FirstAsync(m => m.Id == 1);
            var dateProvider = new DateTimeServiceProvider();

            var adminLogin = admin.AddNewAttempdToLogin("IntegrationTest", dateProvider);

            await context.SaveChangesAsync();
            return adminLogin;
        }

        public async Task<ApplicantRequestLoanResult> WithMockLoanRequestByApplicant()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            if (!context.ApplicantLoanRequests.Any())
            {
                await ConfirmApplicant();
                return await SendAsync(new ApplicantRequestLoanCommand() { ApplicantId = StaticDate.ApplicantId, Amount = 100000.ToToman(), LoanLadderInstallmentsCount = 6, Reason = "Integratation Test " });
            }
            else
            {
                var applicantRequest = context.ApplicantLoanRequests.FirstOrDefault();

                return new ApplicantRequestLoanResult
                {
                    LoanRequestId = applicantRequest.Id,
                    State = applicantRequest.LastState,
                    TrackingNumber = applicantRequest.TrackingNumber
                };
            }
        }

        public async Task SupporterConfirmApplicantLoanRequest(int requestId)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            var supporter = await context.Supporters.FirstAsync(m => m.Id == 1);
            var applicantRequest = context.ApplicantLoanRequests.FirstOrDefault(m => m.Id == requestId);
            supporter.ConfirmApplicantLoanRequest(applicantRequest, new DateTimeServiceProvider());
            context.SaveChanges();
        }

        public async Task RemoveApplicantLoanRequest(int requestId)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<LoanWithUsContext>();
            var supporter = await context.Supporters.FirstAsync(m => m.Id == 1);
            var applicantRequest = context.ApplicantLoanRequests.FirstOrDefault(m => m.Id == requestId);

            applicantRequest.CancelRequest(new DateTimeServiceProvider());

            context.SaveChanges();
        }

        public async Task ConfirmApplicant()
        {
            await SendAsync(new ApplicantVerificationCommand() { ApplicantId = StaticDate.ApplicantId, AdminId = 1 });
        }

    }

}