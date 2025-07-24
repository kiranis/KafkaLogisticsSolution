using System.Threading.Tasks;
using ScanIngestor.Domain.Entities;

namespace ScanIngestor.Domain.Services
{
    public interface IScanEventPublisher
    {
        Task PublishAsync(ScanEvent scanEvent);
    }
}