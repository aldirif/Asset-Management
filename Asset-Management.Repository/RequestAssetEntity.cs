using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management.Repository
{
    [Table("request_asset")]
    public class RequestAssetEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("pic_name")]
        public string PicName { get; set; }

        [Column("pic_address")]
        public string PicAddress { get; set; }

        [Column("specification")]
        public string Specification { get; set; }

        [Column("request_date")]
        public DateTime RequestDate { get; set; }
        public List<ApprovalEntity> Approval { get; set; }
    }
}
