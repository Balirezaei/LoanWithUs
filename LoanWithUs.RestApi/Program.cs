using LoanWithUs.ApplicationService;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.MediatR.PreRequest;
using LoanWithUs.Persistense.EF.ContextContainer;
using LoanWithUs.Persistense.EF.Repository;
using LoanWithUs.Persistense.EF.UnitOfWork;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateApplicantCommand).Assembly);
builder.Services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
//LoggingHandlerDecorator

builder.Services.AddMediatR(typeof(LoggingHandlerDecorator<>).Assembly);

//builder.Services.AddMediatR(typeof(IRequestHandler<>), typeof(LoggingHandlerDecorator<>));
//builder.Services.AddMediatR(typeof(IRequestHandler<>), typeof(LoggingHandlerDecorator<>));
//builder.Services.AddTransient(typeof(IRequestHandler<>), typeof(LoggingHandlerDecorator<>));

//builder.Services.Dec(typeof(IRequestPreProcessor<>), typeof(LoggingHandlerDecorator<>));

//builder.Services.AddMediatR(typeof(LoggingHandlerDecorator<>).Assembly);

builder.Services.AddDbContext<LoanWithUsContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("LoanWithUsContext")));


builder.Services.AddScoped<IUnitOfWork, LoanWithUsUnitOfWork>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>(); 
builder.Services.AddScoped<IApplicantReadRepository, ApplicantReadRepository>();
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:7201/");
//                      });
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
