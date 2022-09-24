using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;
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
                _dataContext.roles.Remove(role);
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
                return await _dataContext.roles.ToListAsync();
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
                return await _dataContext.roles.Where(x => x.Id == id).FirstOrDefaultAsync();
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
                _dataContext.roles.Add(role);
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
                _dataContext.roles.Update(role);
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