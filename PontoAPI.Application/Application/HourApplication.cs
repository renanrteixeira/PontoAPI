using PontoAPI.Application.Interface;
using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Interface;

namespace PontoAPI.Application.Application
{
    public class HourApplication : IApplication<Hour>
    {
        private readonly IRepository<Hour> _dataContext;

        public HourApplication(IRepository<Hour> dataContext)
        {
            _dataContext = dataContext;
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

        public async Task<Hour> Get(int id)
        {
            try
            {
                var hour = await _dataContext.Get(id);
                return hour;
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
                _dataContext.Post(hour);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Hour> Put(Hour hour)
        {
            try
            {
                var hourdb = await _dataContext.Get(hour.Id);
                if (hourdb != null)
                {
                    hourdb.Employefk = hour.Employefk;
                    hourdb.Date = hour.Date;
                    hourdb.Type = hour.Type;
                    hourdb.TypeDatefk = hour.TypeDatefk;
                    hourdb.Hour1 = hour.Hour1;
                    hourdb.Hour2 = hour.Hour2;
                    hourdb.Hour3 = hour.Hour3;
                    hourdb.Hour4 = hour.Hour4;
                    hourdb.Hour5 = hour.Hour5;
                    hourdb.Hour6 = hour.Hour6;
                    hourdb.balance = (hour.Hour2 - hour.Hour1) + (hour.Hour4 - hour.Hour3) + (hour.Hour6 - hour.Hour5);

                    _dataContext.Put(hourdb);

                }
                return await _dataContext.Get(hour.Id);
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