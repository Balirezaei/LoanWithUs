using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Encryption;
using LoanWithUs.Persistense.EF.ContextContainer;
using LoanWithUs.RestApi.Bootstrap;
using LoanWithUs.RestApi.Filter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilterAttribute>();
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

//.AddFluentValidation(x => x.AutomaticValidationEnabled = false)
;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });

    //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    //{
    //    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
    //    In = ParameterLocation.Header,
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.ApiKey
    //});

    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Name = "Authorization",
    //    Scheme = "Bearer",
    //});

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //            {
    //                {
    //                    new OpenApiSecurityScheme()
    //                    {
    //                        Reference = new OpenApiReference()
    //                        {
    //                            Type = ReferenceType.SecurityScheme,
    //                            Id = "Bearer"
    //                        },
    //                        Scheme = "Bearer",
    //                        Type = SecuritySchemeType.Http,
    //                        Name = "Bearer",
    //                        In = ParameterLocation.Header
    //                    }, new List<string>()
    //                }
    //            });

}

    );

builder.Services.AddApplicationServices();
builder.Services.AddFrameworkConfigurationService(Configuration);

var privatekeyDir = Path.Combine(Directory.GetCurrentDirectory(), "Keys", Configuration["Key:PrivateKey"]);
var publicDir = Path.Combine(Directory.GetCurrentDirectory(), "Keys", Configuration["Key:PublicKey"]);
var rsaEcryptionConfig = new RSAEncryptionConfig(privatekeyDir, publicDir, Configuration["Key:PrivatePassword"]);
var rSAEncryption = new LoanRSAEncryption(rsaEcryptionConfig);
builder.Services.AddScoped<ILoanRSAEncryption>(m =>
{
    return rSAEncryption;
});

if (builder.Environment.EnvironmentName != "IntegrationTest")
{
    builder.Services.AddAuthoticationConfigurationService(Configuration, rSAEncryption);
}


builder.Services.AddDbContext<LoanWithUsContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("LoanWithUsContext")));


builder.Services.AddRepositoryAndDomainService();

//if (builder.Environment.ApplicationName != "IntegrationTest") { }
builder.Services.AddScoped<UserDataSecurityDate>(provider =>
{
    var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
    string userAgentHeader = httpContext?.Request?.Headers["User-Agent"] ?? "";
    var authorizationHeader = httpContext?.Request.Headers["Authorization"];
    var userAgent = new UserDataSecurityDate()
    {
        //BrowserType = (short)BrowserDetection.GetBrowserType(userAgentHeader),
        IP = httpContext?.Connection.RemoteIpAddress.ToString(),
        LocalIp = httpContext?.Connection.LocalIpAddress.ToString(),
        //OsType = (short)OsDetection.GetOsType(userAgentHeader),
        //SqlTokenInfoKey = sqlToken
        UserAgent = userAgentHeader
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
