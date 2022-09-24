namespace PontoAPI.Infrastructure.Interface
{
    public interface IRepository<T>
    {

        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        void Post(T entidade);

        void Put(T entidade);

        void Delete(T entidade);

        Task<bool> SaveChangesAsync();

    }
}