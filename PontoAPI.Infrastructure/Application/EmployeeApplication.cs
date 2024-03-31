using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Application
{
    public class EmployeeApplication : IApplication<Employee>
    {

        private readonly IRepository<Employee> _dataContext;

        public EmployeeApplication(IRepository<Employee> dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Employee employee)
        {
            try
            {
                _dataContext.Delete(employee);
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
                return await _dataContext.Get();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Employee> Get(Guid id)
        {
            try
            {
                var employee = await _dataContext.Get(id);
                return employee;
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

        public async Task<Employee> Post(Employee employee)
        {
            try
            {
                employee.Id = new Guid();
                _dataContext.Post(employee);

                return await _dataContext.Get(employee.Id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Employee> Put(Employee employee)
        {
            try
            {
                var employeedb = await _dataContext.Get(employee.Id);
                if (employeedb != null)
                {
                    employeedb.Name = employee.Name;
                    employeedb.Role = employee.Role;
                    employeedb.Admission = employee.Admission;
                    employeedb.Gender = employee.Gender;
                    employeedb.Status = employee.Status;
                    employeedb.Company = employee.Company;

                    _dataContext.Put(employeedb);

                }
                return await _dataContext.Get(employee.Id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Employee> Query()
        {
            return _dataContext.Query();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}