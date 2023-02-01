namespace Asset_Management.ViewModel
{
    public class AuditValidationReq
    {
        public long Id { get; set; }
        public long AssetHistoryId { get; set; }
        public string Condition { get; set; }
        public string TypeWindows { get; set; }
        public string WindowsLicenseUrl { get; set; }
        public string TypeOffice { get; set; }
        public string OfficeLicenseUrl { get; set; }
        public bool Antivirus { get; set; }
        public string AssetPhotoUrl { get; set; }
        public string? Result { get; set; }
    }
}
