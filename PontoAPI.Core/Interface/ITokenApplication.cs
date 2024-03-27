namespace PontoAPI.Core.Interface
{
    public interface ITokenApplication<T>
    {
        Task<T> GetUser(string userName, string password);
    }
}
