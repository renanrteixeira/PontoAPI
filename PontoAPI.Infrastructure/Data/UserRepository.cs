using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;

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
                _dataContext.Users.Remove(user);
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
                return await _dataContext.Users.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> Get(Guid id)
        {
            try
            {
                return await _dataContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> Get(string username)
        {
            try
            {
                return await _dataContext.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
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
                _dataContext.Users.Add(user);
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
                _dataContext.Users.Update(user);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<User> Query()
        {
            return _dataContext.Users;
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