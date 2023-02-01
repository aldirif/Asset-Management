namespace Asset_Management.ViewModel
{
    public class AssetModel
    {
        public long Id { get; set; }
        public string AssetName { get; set; }
        public string Specification { get; set; }
        public string SerialNumber { get; set; }
        public int PurchaseYear { get; set; }
    }
}