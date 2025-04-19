using DockerVolumesPersistency.Models;

namespace DockerVolumesPersistency.Interfaces
{
    public interface ICounterService
    {
        Task<Counters> IncrementAsync(string counterId);

        Task<Counters?> GetAsync(string counterId);
    }
}
