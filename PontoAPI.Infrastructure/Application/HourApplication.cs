using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PontoAPI.Infrastructure.Application
{
    public class HourApplication : IApplication<Hour>
    {
        private readonly IRepository<Hour> _dataContext;
        private readonly IRepository<TypeDate> _dataContextTypeDate;

        public HourApplication(IRepository<Hour> dataContext, IRepository<TypeDate> dataContextTypeDate)
        {
            _dataContext = dataContext;
            _dataContextTypeDate = dataContextTypeDate;
        }

        public void Delete(Hour hour)
        {
            try
            {
                _dataContext.Delete(hour);
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
                return await _dataContext.Get();
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
                var hour = await _dataContext.Get(guid);
                return hour;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Task<Hour> Get(string value)
        {
            throw new NotImplementedException();
        }

        public async Task<Hour> Post(Hour hour)
        {
            try
            {
                var horasLancadas = _dataContext.Query().Where(p => p.EmployeeId == hour.EmployeeId && p.Date == hour.Date && p.Type == hour.Type).ToList();
                if (horasLancadas.Count > 0) throw new Exception("Data já cadastrada para o tipo de dado!");
                hour.Id = new Guid();
                var hourBase = await _dataContextTypeDate.Get(hour.TypeDateId) ?? throw new Exception("Tipo de hora não identificada!");
                hour.Balance = ((hour.Hour2 - hour.Hour1) + (hour.Hour4 - hour.Hour3) + (hour.Hour6 - hour.Hour5)) - hourBase.Time;

                _dataContext.Post(hour);

                return await _dataContext.Get(hour.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Hour> Put(Hour hour)
        {
            try
            {
                var hourdb = await _dataContext.Get(hour.Id);
                if (hourdb != null)
                {
                    hourdb.Employee = hour.Employee;
                    hourdb.Date = hour.Date;
                    hourdb.Type = hour.Type;
                    hourdb.TypeDate = hour.TypeDate;
                    hourdb.Hour1 = hour.Hour1;
                    hourdb.Hour2 = hour.Hour2;
                    hourdb.Hour3 = hour.Hour3;
                    hourdb.Hour4 = hour.Hour4;
                    hourdb.Hour5 = hour.Hour5;
                    hourdb.Hour6 = hour.Hour6;

                    var hourBase = await _dataContextTypeDate.Get(hour.TypeDateId) ?? throw new Exception("Tipo de hora não identificada!");
                    hour.Balance = ((hour.Hour2 - hour.Hour1) + (hour.Hour4 - hour.Hour3) + (hour.Hour6 - hour.Hour5)) - hourBase.Time;

                    _dataContext.Put(hourdb);

                }
                return await _dataContext.Get(hour.Id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Hour> Query()
        {
            return _dataContext.Query();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}