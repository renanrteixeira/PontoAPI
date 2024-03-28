namespace PontoAPI.Core.Interface
{
    public interface IRepository<T>
    {

        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task<T> Get(string value);

        void Post(T entidade);

        void Put(T entidade);

        void Delete(T entidade);

        Task<bool> SaveChangesAsync();

    }
}