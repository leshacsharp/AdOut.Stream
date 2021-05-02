using System.Threading.Tasks;

namespace AdOut.Stream.Model.Interfaces
{
    public interface IAuthorizationClientWrapper<TClient>
    {
        Task<TClient> GetClientAsync();
    }
}
