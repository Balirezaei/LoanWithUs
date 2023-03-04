using System.Text;
using LoanWithUs.Encryption;
using LoanWithUs.RestApi.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LoanWithUs.RestApi.Bootstrap
{
    public static class AuthoticationConfigurationService
    {
        public static IServiceCollection AddAuthoticationConfigurationService(this IServiceCollection services, IConfiguration Configuration, ILoanRSAEncryption rSAEncryption)
        {
            RsaSecurityKey signingKey = new RsaSecurityKey(rSAEncryption.GetRsaWithPublicKey());

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}