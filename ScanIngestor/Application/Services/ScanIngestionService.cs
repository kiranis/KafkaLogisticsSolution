using ScanIngestor.Domain.Entities;
using ScanIngestor.Domain.Services;
using System.Threading.Tasks;

namespace ScanIngestor.Application.Services
{
    public class ScanIngestionService
    {
        private readonly IScanEventPublisher _eventPublisher;

        public ScanIngestionService(IScanEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task IngestScanAsync(ScanEvent scanEvent)
        {
            // Add any business logic or validation here
            await _eventPublisher.PublishAsync(scanEvent);
        }
    }
}