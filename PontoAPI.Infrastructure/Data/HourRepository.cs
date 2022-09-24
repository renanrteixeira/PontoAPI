using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;

namespace PontoAPI.Infrastructure.Data
{
    public class HourRepository : IRepository<Hour>
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
                _dataContext.hours.Remove(hour);
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
                return await _dataContext.hours.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Hour> Get(int id)
        {
            try
            {
                return await _dataContext.hours.Where(x => x.Id == id).FirstOrDefaultAsync();
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
                _dataContext.hours.Add(hour);
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
                _dataContext.hours.Update(hour);
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