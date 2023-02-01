using Asset_Management.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management.Repository
{
    [Table("asset")]
    public class AssetEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("asset_name")]
        public string AssetName { get; set; }

        [Column("specification")]
        public string Specification { get; set; }

        [Column("serial_number")]
        public string SerialNumber { get; set; }

        [Column("purchase_year")]
        public int PurchaseYear { get; set; }

        // public bool Available { get; set; }

        public List<AssetHistoryEntity> AssetHistory { get; set; }

        public AssetEntity() { }
        public AssetEntity(AssetModel model)
        {
            this.Id = model.Id;
            this.AssetName = model.AssetName;
            this.Specification = model.Specification;
            this.SerialNumber = model.SerialNumber;
            this.PurchaseYear = model.PurchaseYear;
        }
    }
}
