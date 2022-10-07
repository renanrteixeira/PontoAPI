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

        public async Task<Role> Get(int id)
        {
            try
            {
                var company = await _dataContext.Get(id);
                return company;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Post(Role role)
        {
            try
            {
                _dataContext.Post(role);
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

    }
}