namespace PontoAPI.Infrastructure.Interface
{
    public interface IRepository<T>
    {

        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        void Post(T company);

        void Put(T company);

        void Delete(T company);

        Task<bool> SaveChangesAsync();

    }
}