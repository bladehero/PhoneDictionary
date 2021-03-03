using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PhoneDictionary.Extensions
{
    public static class SecurityKeyExtensions
    {
        public static SecurityKey GetSymmetricSecurityKey(this string secret)
        {
            var bytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(bytes);
        }
    }
}