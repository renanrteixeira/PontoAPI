using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;

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
                _dataContext.typedates.Remove(typeDate);
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
                return await _dataContext.typedates.ToListAsync();
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
                return await _dataContext.typedates.Where(x => x.Id == id).FirstOrDefaultAsync();
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
                _dataContext.typedates.Add(typeDate);
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
                _dataContext.typedates.Update(typeDate);
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