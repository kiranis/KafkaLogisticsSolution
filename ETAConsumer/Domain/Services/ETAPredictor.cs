using ETAConsumer.Services;
using System;

namespace ETAConsumer.Domain.Services
{
    public class ETAPredictor : IETAPredictor
    {
        public DateTime Predict(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime.AddHours(2);
        }
    }
}