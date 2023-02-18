using System.Security.Cryptography;
using FluentValidation.AspNetCore;
using LoanWithUs.ApplicationService;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.DomainService;
using LoanWithUs.Encryption;
using LoanWithUs.MediatR.PreRequest;
using LoanWithUs.Persistense.EF.ContextContainer;
using LoanWithUs.Persistense.EF.Repository;
using LoanWithUs.Persistense.EF.UnitOfWork;
using LoanWithUs.RestApi.Bootstrap;
using LoanWithUs.RestApi.Filter;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.


builder.Services.AddControllersWithViews(options =>
    options.Filters.Add<ApiExceptionFilterAttribute>())
        .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddFrameworkConfigurationService(Configuration);

var privatekeyDir = Path.Combine(Directory.GetCurrentDirectory(), "Keys", Configuration["Key:PrivateKey"]);
var publicDir = Path.Combine(Directory.GetCurrentDirectory(), "Keys", Configuration["Key:PublicKey"]);
var rsaEcryptionConfig = new RSAEncryptionConfig(privatekeyDir, publicDir, Configuration["Key:PrivatePassword"]);
var rSAEncryption=new LoanRSAEncryption(rsaEcryptionConfig);
builder.Services.AddScoped<ILoanRSAEncryption>(m =>
{
    return rSAEncryption;
});
builder.Services.AddAuthoticationConfigurationService(Configuration,rSAEncryption);

builder.Services.AddDbContext<LoanWithUsContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("LoanWithUsContext")));


builder.Services.AddRepositoryConfigurationService();

//if (builder.Environment.ApplicationName != "IntegrationTest") { }
builder.Services.AddScoped<UserDataSecurityِate>(provider =>
{
    var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
    string userAgentHeader = httpContext?.Request?.Headers["User-Agent"] ?? "";
    var authorizationHeader = httpContext?.Request.Headers["Authorization"];
    var userAgent = new UserDataSecurityِate()
    {
        //BrowserType = (short)BrowserDetection.GetBrowserType(userAgentHeader),
        IP = httpContext?.Connection.RemoteIpAddress.ToString(),
        LocalIp = httpContext?.Connection.LocalIpAddress.ToString(),
        //OsType = (short)OsDetection.GetOsType(userAgentHeader),
        //SqlTokenInfoKey = sqlToken
        UserAgent= userAgentHeader
    };
    return userAgent;
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("*")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                                .WithExposedHeaders("Token-Expired");
                          });
    });






// builder.Services.AddScoped<RSACryptoServiceProvider>(m=>{
//     return rsa;
// });

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
