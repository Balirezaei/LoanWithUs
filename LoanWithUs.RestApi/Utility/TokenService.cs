using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using LoanWithUs.Encryption;
using Microsoft.IdentityModel.Tokens;

namespace LoanWithUs.RestApi.Utility
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoanRSAEncryption _rSAEncryption;

        public TokenService(IConfiguration configuration, ILoanRSAEncryption rSAEncryption)
        {
            _configuration = configuration;
            _rSAEncryption = rSAEncryption;
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            // RSA privateRsa = RSA.Create();
            // var privatekeyDir = Path.Combine(Directory.GetCurrentDirectory(),
            //     "Keys",
            //     this._configuration.GetValue<String>("PrivateKey")
            // );
            // privateRsa.FromXmlFile(privatekeyDir);


            var privateKey = new RsaSecurityKey(_rSAEncryption.GetRSAWithPrivateKey());

            SigningCredentials signingCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);

            var jwtToken = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:Duration"])),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var pubKey = new RsaSecurityKey(_rSAEncryption.GetRsaWithPublicKey());
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = pubKey,
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.RsaSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;


        }
    }
}