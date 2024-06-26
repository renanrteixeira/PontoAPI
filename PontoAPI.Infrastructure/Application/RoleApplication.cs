using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Application
{
    public class RoleApplication : IApplication<Role>
    {
        private readonly IRepository<Role> _dataContext;

        public RoleApplication(IRepository<Role> dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Role>> Get()
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

        public async Task<Role> Get(Guid id)
        {
            try
            {
                var role = await _dataContext.Get(id);
                return role;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Role> Post(Role role)
        {
            try
            {
                role.Id = Guid.NewGuid();
                _dataContext.Post(role);

                return await _dataContext.Get(role.Id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Role> Put(Role role)
        {
            try
            {
                var roledb = await _dataContext.Get(role.Id);
                if (roledb != null)
                {
                    roledb.Name = role.Name;
                    _dataContext.Put(roledb);

                }
                return await _dataContext.Get(role.Id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Role role)
        {
            try
            {
                _dataContext.Delete(role);
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

        public IQueryable<Role> Query()
        {
            return _dataContext.Query();
        }
    }
}