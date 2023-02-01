using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management.Repository
{
    [Table("asset_history")]
    public class AssetHistoryEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("asset_id")]
        public long AssetId { get; set; }

        public AssetEntity Asset { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("pic_id")]
        public long PicId { get; set; }
        public PicEntity Pic { get; set; }

        [Column("send_date")]
        public DateTime SendDate { get; set; }

        //public DateTime ReturnDate { get; set; }

        public List<AuditEntity> Audit { get; set; }
    }
}
