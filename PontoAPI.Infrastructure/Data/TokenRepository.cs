using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;

namespace PontoAPI.Infrastructure.Data
{
    public class TokenRepository : ITokenRepository<User>
    {
        private readonly DataContext _dataContext;

        public TokenRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetUser(string userName, string password)
        {
            try
            {
                return await _dataContext.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }


    }
}