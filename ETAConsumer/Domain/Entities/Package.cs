namespace ETAConsumer.Domain.Entities
{
    public class Package
    {
        public string PackageId { get; set; }
        public string Location { get; set; }
        public long ScanTimestamp { get; set; }
        public string ScanType { get; set; }
    }
}