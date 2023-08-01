using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace PontoAPI.Infrastructure.Data
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Employee employee)
        {
            try
            {
                _dataContext.employees.Remove(employee);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Employee>> Get()
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

        public async Task<Employee> Get(int id)
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

        public void Post(Employee employee)
        {
            try
            {
                _dataContext.employees.Add(employee);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Put(Employee employee)
        {
            try
            {
                _dataContext.employees.Update(employee);
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