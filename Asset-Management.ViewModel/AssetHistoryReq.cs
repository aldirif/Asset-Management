namespace Asset_Management.ViewModel
{
    public class AssetHistoryReq
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public string Location { get; set; }
        public long PicId { get; set; }
        public DateTime SendDate { get; set; }
    }
}
