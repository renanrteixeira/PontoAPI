namespace PontoAPI.Core.Interface
{
    public interface IApplication<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(Guid id);

        Task<T> Post(T entidade);

        Task<T> Put(T entidade);

        IQueryable<T> Query();

        void Delete(T entidade);

        Task<bool> SaveChangesAsync();
    }
}