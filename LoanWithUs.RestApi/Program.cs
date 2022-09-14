using FluentValidation.AspNetCore;
using LoanWithUs.ApplicationService;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.DomainService;
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

builder.Services.AddDbContext<LoanWithUsContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("LoanWithUsContext")));


builder.Services.AddScoped<IUnitOfWork, LoanWithUsUnitOfWork>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IApplicantReadRepository, ApplicantReadRepository>();
builder.Services.AddScoped<IApplicantDomainService, ApplicantDomainService>();

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


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
