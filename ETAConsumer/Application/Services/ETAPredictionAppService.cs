using ETAConsumer.Domain.Entities;
using ETAConsumer.Domain.Services;
using ETAConsumer.Models;

namespace ETAConsumer.Application.Services
{
    public class ETAPredictionAppService
    {
        private readonly ETAService _etaService;

        public ETAPredictionAppService(ETAService etaService)
        {
            _etaService = etaService;
        }

        public ETAPrediction Predict(Package package)
        {
            var eta = _etaService.CalculateETA(package.ScanTimestamp);
            return new ETAPrediction
            {
                PackageId = package.PackageId,
                Location = package.Location,
                ScanTimestamp = package.ScanTimestamp,
                ETA = eta
            };
        }
    }
}