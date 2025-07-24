using System;

namespace ETAConsumer.Domain.Services
{
    public interface IETAPredictor
    {
        DateTime Predict(long timestamp);
    }
}