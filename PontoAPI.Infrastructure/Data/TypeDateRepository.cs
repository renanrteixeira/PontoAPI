using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;

namespace PontoAPI.Infrastructure.Data
{
    public class TypeDateRepository : IRepository<TypeDate>
    {
        private readonly DataContext _dataContext;

        public TypeDateRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(TypeDate typeDate)
        {
            try
            {
                _dataContext.Typedates.Remove(typeDate);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<TypeDate>> Get()
        {
            try
            {
                return await _dataContext.Typedates.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<TypeDate> Get(int id)
        {
            try
            {
                return await _dataContext.Typedates.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Post(TypeDate typeDate)
        {
            try
            {
                _dataContext.Typedates.Add(typeDate);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Put(TypeDate typeDate)
        {
            try
            {
                _dataContext.Typedates.Update(typeDate);
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