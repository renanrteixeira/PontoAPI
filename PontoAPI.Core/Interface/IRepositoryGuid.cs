using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoAPI.Core.Interface
{
    public interface IRepositoryGuid<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(Guid guid);

        void Post(T entidade);

        void Put(T entidade);

        void Delete(T entidade);

        Task<bool> SaveChangesAsync();
    }
}