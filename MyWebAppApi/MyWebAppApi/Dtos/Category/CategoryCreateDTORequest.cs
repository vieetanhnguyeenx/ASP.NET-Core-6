using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi.Dtos.Category
{
    public class CategoryCreateDTORequest
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
