using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;
using MySqlConnector;

namespace PontoAPI.Infrastructure.Application
{
    public class CompanyApplication : IApplication<Company>
    {
        private readonly IRepository<Company> _dataContext;

        public CompanyApplication(IRepository<Company> dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Company company)
        {
            try
            {
                _dataContext.Delete(company);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Company>> Get()
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

        public async Task<Company> Get(Guid id)
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

        public Task<Company> Get(string value)
        {
            throw new NotImplementedException();
        }

        public void Post(Company company)
        {
            try
            {
                company.Id = new Guid();
                _dataContext.Post(company);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Company> Put(Company company)
        {
            try
            {
                var companydb = await _dataContext.Get(company.Id);
                if (companydb != null)
                {
                    companydb.Name = company.Name;
                    companydb.Address = company.Address;
                    companydb.Telephone = company.Telephone;

                    _dataContext.Put(companydb);

                }
                return await _dataContext.Get(company.Id);
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