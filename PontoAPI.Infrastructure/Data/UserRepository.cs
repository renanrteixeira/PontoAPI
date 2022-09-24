using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;

namespace PontoAPI.Infrastructure.Data
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(User user)
        {
            try
            {
                _dataContext.users.Remove(user);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            try
            {
                return await _dataContext.users.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> Get(int id)
        {
            try
            {
                return await _dataContext.users.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Post(User user)
        {
            try
            {
                _dataContext.users.Add(user);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Put(User user)
        {
            try
            {
                _dataContext.users.Update(user);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}