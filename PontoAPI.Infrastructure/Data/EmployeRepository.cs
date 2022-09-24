using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace PontoAPI.Infrastructure.Data
{
    public class EmployeRepository : IRepository<Employe>
    {
        private readonly DataContext _dataContext;

        public EmployeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Employe employe)
        {
            try
            {
                _dataContext.employees.Remove(employe);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Employe>> Get()
        {
            try
            {
                return await _dataContext.employees.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Employe> Get(int id)
        {
            try
            {
                return await _dataContext.employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Post(Employe employe)
        {
            try
            {
                _dataContext.employees.Add(employe);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Put(Employe employe)
        {
            try
            {
                _dataContext.employees.Update(employe);
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