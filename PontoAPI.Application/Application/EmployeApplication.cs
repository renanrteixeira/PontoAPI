using PontoAPI.Application.Interface;
using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;

namespace PontoAPI.Application.Application
{
    public class EmployeApplication : IApplication<Employe>
    {

        private readonly IRepository<Employe> _dataContext;

        public EmployeApplication(IRepository<Employe> dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Employe employe)
        {
            try
            {
                _dataContext.Delete(employe);
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
                return await _dataContext.Get();
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
                var employe = await _dataContext.Get(id);
                return employe;
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
                _dataContext.Post(employe);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Employe> Put(Employe employe)
        {
            try
            {
                var employedb = await _dataContext.Get(employe.Id);
                if (employedb != null)
                {
                    employedb.Name = employe.Name;
                    employedb.Rolefk = employe.Rolefk;
                    employedb.Admission = employe.Admission;
                    employedb.Gender = employe.Gender;
                    employedb.Status = employe.Status;
                    employedb.Employefk = employe.Employefk;

                    _dataContext.Put(employedb);

                }
                return await _dataContext.Get(employe.Id);
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