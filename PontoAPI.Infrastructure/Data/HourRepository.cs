using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;

namespace PontoAPI.Infrastructure.Data
{
    public class HourRepository : IRepositoryGuid<Hour>
    {
        private readonly DataContext _dataContext;

        public HourRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(Hour hour)
        {
            try
            {
                _dataContext.Hours.Remove(hour);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Hour>> Get()
        {
            try
            {
                return await _dataContext.Hours.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Hour> Get(Guid guid)
        {
            try
            {
                return await _dataContext.Hours.Where(x => x.Id == guid).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Post(Hour hour)
        {
            try
            {
                _dataContext.Hours.Add(hour);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Put(Hour hour)
        {
            try
            {
                _dataContext.Hours.Update(hour);
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