using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Application
{
    public class HourApplication : IApplicationGuid<Hour>
    {
        private readonly IRepositoryGuid<Hour> _dataContext;

        public HourApplication(IRepositoryGuid<Hour> dataContext)
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

        public void Post(Hour hour)
        {
            try
            {
                hour.Id = new Guid();
                hour.Balance = (hour.Hour2 - hour.Hour1) + (hour.Hour4 - hour.Hour3) + (hour.Hour6 - hour.Hour5);

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
                    hourdb.Balance = (hour.Hour2 - hour.Hour1) + (hour.Hour4 - hour.Hour3) + (hour.Hour6 - hour.Hour5);

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