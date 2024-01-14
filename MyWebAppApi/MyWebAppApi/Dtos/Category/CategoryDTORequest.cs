using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi.Dtos.Category
{
    public class CategoryDTORequest
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
