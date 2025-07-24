using System;

namespace ETAConsumer.Events
{
    public class ETAPredictedEvent
    {
        public string PackageId { get; set; }
        public string Location { get; set; }
        public DateTime ETA { get; set; }
    }
}