using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAppApi.Entity
{
    [Table("Products")]
    public class Product
    {
        [Column(TypeName = "BigInt")]
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [DefaultValue("")]
        public string Description { get; set; } = "";

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [DefaultValue(0)]
        public double Discount { get; set; } = 0;

    }
}
