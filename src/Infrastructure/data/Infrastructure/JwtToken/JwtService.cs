using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Options;
using Interface;
using DTO.Configuration;

namespace Data.Infrastructure.JwtToken
{
   
    public class JwtService : IJwtService
    {

        private readonly JWT _appSettings;

        public JwtService(IOptions<JWT> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string CreateToken(Dictionary<string, string> keyValuePairs, DateTime tokenValidity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new Claim[keyValuePairs.Count];
            int i = 0;
            foreach (var keyValue in keyValuePairs)
            {
                claims[i++] = new Claim(keyValue.Key, keyValue.Value??"");
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenValidity,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public Dictionary<string, string> GetTokenClaims(string token, List<string> claims = null)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            List<Exception> validationFailures = null;
            SecurityToken validatedToken;
            var validator = new JwtSecurityTokenHandler();

            // These need to match the values used to generate the token
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };


            if (validator.CanReadToken(token))
            {
                ClaimsPrincipal principal;
                try
                {
                    // This line throws if invalid
                    principal = validator.ValidateToken(token, validationParameters, out validatedToken);

                    var keyValue = new Dictionary<string, string>();
                    if (claims == null)
                        return keyValue;
                    // If we got here then the token is valid
                    foreach (var claim in claims)
                    {
                        if (principal.HasClaim(c => c.Type == claim))
                        {
                            keyValue.Add(claim, principal.Claims.Where(c => c.Type == claim).First().Value);

                        }
                    }
                    return keyValue;
                }
                catch (Exception e)
                {

                }
            }

            return null;
        }

    }
}
