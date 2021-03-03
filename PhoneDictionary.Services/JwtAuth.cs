using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PhoneDictionary.Data.Services;
using PhoneDictionary.Extensions;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.Services
{
    public class JwtAuth : IAuth
    {
        private readonly IDbContext _dbContext;
        private readonly AuthenticationConfig _authenticationConfig;

        public JwtAuth(IOptions<AuthenticationConfig> authenticationConfig, IDbContext dbContext)
        {
            _dbContext = dbContext;
            _authenticationConfig = authenticationConfig.Value;
        }

        public string GetToken(string login, string password)
        {
            var identity = GetIdentity(login, password);
            if (identity == null)
            {
                throw new AuthenticationException("Invalid username or password.");
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                _authenticationConfig.Issuer,
                _authenticationConfig.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authenticationConfig.Lifetime)),
                signingCredentials: new SigningCredentials(_authenticationConfig.Key.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return token;
        }
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var hash = password.ToMD5HashString();
            var user = _dbContext.Moderators.FirstOrDefault(x => x.Login == username && x.Password == hash);
            if (user == null)
            {
                return null;
            }

            var claims = new Claim[]
            {
                new(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}