namespace Asset_Management.ViewModel
{
    public class AssetHistoryResponse
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public string AssetName { get; set; }
        public string Specification { get; set; }
        public string SerialNumber { get; set; }
        public int PurchaseYear { get; set; }

        public string Location { get; set; }
        public long PicId { get; set; }
        public string PicName { get; set; }
        public DateTime SendDate { get; set; }

    }
}
