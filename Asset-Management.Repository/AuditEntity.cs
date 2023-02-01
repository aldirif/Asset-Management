using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management.Repository
{
    [Table("audit")]
    public class AuditEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("asset_history_id")]
        public long AssetHistoryId { get; set; }
        public AssetHistoryEntity AssetHistory { get; set; }

        [Column("condition")]
        public string Condition { get; set; }

        [Column("type_windows")]
        public string TypeWindows { get; set; }

        [Column("windows_license_url")]
        public string WindowsLicenseUrl { get; set; }

        [NotMapped]
        public IFormFile WindowsLicense { get; set; }

        [Column("type_office")]
        public string TypeOffice { get; set; }

        [Column("office_license_url")]
        public string OfficeLicenseUrl { get; set; }

        [NotMapped]
        public IFormFile OfficeLicense { get; set; }

        [Column("antivirus")]
        public bool Antivirus { get; set; }

        [Column("asset_photo_url")]
        public string AssetPhotoUrl { get; set; }

        [NotMapped]
        public IFormFile AssetPhoto { get; set; }

        [Column("result")]
        public string? Result { get; set; }

    }
}
