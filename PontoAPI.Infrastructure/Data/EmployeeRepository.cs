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
                _dataContext.Employees.Remove(employee);
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
                return await _dataContext.Employees.ToListAsync();
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
                return await _dataContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Task<Employee> Get(string value)
        {
            throw new NotImplementedException();
        }

        public void Post(Employee employee)
        {
            try
            {
                _dataContext.Employees.Add(employee);
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
                _dataContext.Employees.Update(employee);
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