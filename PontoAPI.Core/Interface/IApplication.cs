namespace PontoAPI.Core.Interface
{
    public interface IApplication<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(Guid id);

        Task<T> Get(string value);

        Task<T> Post(T entidade);

        Task<T> Put(T entidade);

        void Delete(T entidade);

        Task<bool> SaveChangesAsync();
    }
}