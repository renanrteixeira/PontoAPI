namespace PontoAPI.Core.Interface
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(Guid id);

        void Post(T entidade);

        void Put(T entidade);

        void Delete(T entidade);

        Task<bool> SaveChangesAsync();

        IQueryable<T> Query();

    }
}