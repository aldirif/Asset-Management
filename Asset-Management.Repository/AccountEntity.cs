using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management.Repository
{
    [Table("account")]
    public class AccountEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("role")]
        public string Role { get; set; }
    }
}
