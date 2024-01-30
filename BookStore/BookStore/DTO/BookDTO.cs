using System.ComponentModel.DataAnnotations;

namespace BookStore.DTO
{
    public class BookDTORequest
    {
        [MaxLength(100)]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}
