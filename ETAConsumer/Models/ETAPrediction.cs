using System;

namespace ETAConsumer.Models
{
    public class ETAPrediction
    {
        public int Id { get; set; }
        public string PackageId { get; set; }
        public string Location { get; set; }
        public long ScanTimestamp { get; set; }
        public DateTime ETA { get; set; }
    }
}