namespace Asset_Management.ViewModel
{
    public class AssetListResponse
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public string? AssetNameWithSnSpec { get; set; }
        public string Specification { get; set; }
        public string SerialNumber { get; set; }
        public int PurchaseYear { get; set; }
    }
}