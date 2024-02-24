namespace PontoAPI.Core.Interface
{
    public interface ITokenRepository<T>
    {
        Task<T> GetUser(string userName, string password);
    }
}