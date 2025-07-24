using System;

namespace ETAConsumer.Domain.Services
{
    public class ETAService
    {
        public DateTime CalculateETA(long scanTimestamp)
        {
            // Business logic for ETA calculation
            return DateTimeOffset.FromUnixTimeMilliseconds(scanTimestamp).UtcDateTime.AddHours(2);
        }
    }
}