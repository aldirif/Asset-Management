namespace Asset_Management.ViewModel
{
    public class RequestAssetDetailResponse
    {
        public long Id { get; set; }
        public string PicName { get; set; }
        public string PicAddress { get; set; }
        public string Specification { get; set; }
        public DateTime RequestDate { get; set; }

        public List<ApprovalResponse> approval = new List<ApprovalResponse>();

    }
}
