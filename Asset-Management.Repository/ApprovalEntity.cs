using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management.Repository
{
    [Table("approval")]
    public class ApprovalEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("request_asset_id")]
        public long RequestAssetId { get; set; }
        public RequestAssetEntity RequestAsset { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("reason")]
        public string Reason { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
    }
}
