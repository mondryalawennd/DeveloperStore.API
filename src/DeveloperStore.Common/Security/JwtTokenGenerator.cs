using Microsoft.Extensions.Options;

namespace DeveloperStore.Common.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly string _jwtSecret;

        public JwtTokenGenerator(IOptions<JwtSettings> options)
        {
            _jwtSecret = options.Value.Secret;
        }
    }
}
