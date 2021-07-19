using System.Threading.Tasks;

namespace AdOut.Stream.Model.Interfaces
{
    public interface IAdQueueRefresher
    {
        Task StartAsync();
    }
}
