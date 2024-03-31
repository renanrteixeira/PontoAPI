using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace PontoAPI.Infrastructure.Data
{
    public class CompanyRepository : IRepository<Company>
    {

        private readonly DataContext _dataContext;

        public CompanyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Company company)
        {
            try
            {
                _dataContext.Companies.Remove(company);
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
                return await _dataContext.Companies.ToListAsync();
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
                return await _dataContext.Companies.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Post(Company company)
        {
            try
            {
                _dataContext.Companies.Add(company);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Put(Company company)
        {
            try
            {
                _dataContext.Companies.Update(company);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Company> Query()
        {
            return _dataContext.Companies;
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