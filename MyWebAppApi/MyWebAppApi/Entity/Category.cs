using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAppApi.Entity
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column(TypeName = "BigInt")]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; }
    }
}
