using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Helper;

namespace PontoAPI.Infrastructure.Application
{
    public class TokenApplication : ITokenApplication<User>
    {
        private readonly ITokenRepository<User> _dataContext;

        public TokenApplication(ITokenRepository<User> dataContext)
        {
            _dataContext = dataContext;
        }
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<User> GetUser(string userName, string password)
        {
            try
            {
                var hashPassword = Hash.GerarHash(password);
                return await _dataContext.GetUser(userName, hashPassword);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}