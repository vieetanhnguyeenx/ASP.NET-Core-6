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

    public class BookDTOResponse
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
