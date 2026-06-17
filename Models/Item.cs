using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campus_Cart_Student_Marketplace.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Price must be greater than 0.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = "/img/belleze.webp";

        [StringLength(50)]
        public string Condition { get; set; } = "Used";

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } 

        [Required]
        public int CategoryId { get; set; }
        public string SellerId { get; set; } = string.Empty;
    }
}