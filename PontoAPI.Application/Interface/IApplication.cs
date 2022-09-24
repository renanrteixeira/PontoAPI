namespace PontoAPI.Application.Interface
{
    public interface IApplication<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        void Post(T company);

        Task<T> Put(T company);

        void Delete(T company);

        Task<bool> SaveChangesAsync();
    }
}