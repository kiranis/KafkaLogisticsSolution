namespace ETAConsumer.Models
{
    public class ScanEvent
    {
        public string PackageId { get; set; }
        public string Location { get; set; }
        public long Timestamp { get; set; }
        public string ScanType { get; set; }
    }
}