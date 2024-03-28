using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Application
{
    public class TypeDateApplication : IApplication<TypeDate>
    {
        private readonly IRepository<TypeDate> _dataContext;

        public TypeDateApplication(IRepository<TypeDate> dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(TypeDate typeDate)
        {
            try
            {
                _dataContext.Delete(typeDate);
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
                return await _dataContext.Get();
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
                var company = await _dataContext.Get(id);
                return company;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Task<TypeDate> Get(string value)
        {
            throw new NotImplementedException();
        }

        public void Post(TypeDate typeDate)
        {
            try
            {
                _dataContext.Post(typeDate);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<TypeDate> Put(TypeDate typeDate)
        {
            try
            {
                var typeDatedb = await _dataContext.Get(typeDate.Id);
                if (typeDatedb != null)
                {
                    typeDatedb.Name = typeDate.Name;
                    typeDatedb.Time = typeDate.Time;
                    typeDatedb.Weekend = typeDate.Weekend;

                    _dataContext.Put(typeDatedb);

                }
                return await _dataContext.Get(typeDate.Id);
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