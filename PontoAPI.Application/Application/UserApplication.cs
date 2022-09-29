using PontoAPI.Application.Interface;
using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;

namespace PontoAPI.Application.Application
{
    public class UserApplication : IApplication<User>
    {
        private readonly IRepository<User> _dataContext;

        public UserApplication(IRepository<User> dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(User user)
        {
            try
            {
                _dataContext.Delete(user);
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
                return await _dataContext.Get();
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
                var user = await _dataContext.Get(id);
                return user;
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
                _dataContext.Post(user);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> Put(User user)
        {
            try
            {
                var userdb = await _dataContext.Get(user.Id);
                if (userdb != null)
                {
                    userdb.Name = user.Name;
                    userdb.Email = user.Email;
                    userdb.Password = user.Password;
                    userdb.Admin = user.Admin;
                    userdb.Status = user.Status;

                    _dataContext.Put(userdb);

                }
                return await _dataContext.Get(user.Id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}