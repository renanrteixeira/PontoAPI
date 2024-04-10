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

        public async Task<TypeDate> Get(Guid id)
        {
            try
            {
                var typeDate = await _dataContext.Get(id);
                return typeDate;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<TypeDate> Post(TypeDate typeDate)
        {
            try
            {
                typeDate.Id = Guid.NewGuid();
                _dataContext.Post(typeDate);

                return await _dataContext.Get(typeDate.Id);
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

        public IQueryable<TypeDate> Query()
        {
            return _dataContext.Query();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}