using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management.Repository
{
    [Table("pic")]
    public class PicEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        public List<AssetHistoryEntity> AssetHistories { get; set; }

    }
}
