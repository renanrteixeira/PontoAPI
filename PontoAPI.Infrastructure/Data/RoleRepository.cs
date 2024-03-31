using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace PontoAPI.Infrastructure.Data
{
    public class RoleRepository : IRepository<Role>
    {

        private readonly DataContext _dataContext;

        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Role role)
        {
            try
            {
                _dataContext.Roles.Remove(role);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Role>> Get()
        {
            try
            {
                return await _dataContext.Roles.ToListAsync();
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
                return await _dataContext.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
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
                _dataContext.Roles.Add(role);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Put(Role role)
        {
            try
            {
                _dataContext.Roles.Update(role);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Role> Query()
        {
            return _dataContext.Roles;
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