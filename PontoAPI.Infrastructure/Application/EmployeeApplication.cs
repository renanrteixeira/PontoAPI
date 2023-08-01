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

        public async Task<Employee> Get(int id)
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

        public void Post(Employee employee)
        {
            try
            {
                _dataContext.Post(employee);
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
                    employeedb.Rolefk = employee.Rolefk;
                    employeedb.Admission = employee.Admission;
                    employeedb.Gender = employee.Gender;
                    employeedb.Status = employee.Status;
                    employeedb.Employeefk = employee.Employeefk;

                    _dataContext.Put(employeedb);

                }
                return await _dataContext.Get(employee.Id);
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