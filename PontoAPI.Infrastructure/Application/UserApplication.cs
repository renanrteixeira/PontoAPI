using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Helper;

namespace PontoAPI.Infrastructure.Application
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

        public async Task<User> Get(Guid id)
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

        public async Task<User> Post(User user)
        {
            try
            {
                var userDb = _dataContext.Query().Where(p => p.UserName == user.UserName).ToList();
                if (userDb.Count > 0) throw new Exception("Usuário já cadastrado!");

                user.Id = new Guid();
                user.Password = Hash.GerarHash(user.Password);
                _dataContext.Post(user);

                return await _dataContext.Get(user.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> Put(User user)
        {
            try
            {
                user.Password = Hash.GerarHash(user.Password);
                _dataContext.Put(user);

                return await _dataContext.Get(user.Id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<User> Query()
        {
            return _dataContext.Query();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}