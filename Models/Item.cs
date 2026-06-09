using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campus_Cart_Student_Marketplace.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product title is required.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 10000.00)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; } = "images/placeholder.png";

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        public bool IsSold { get; set; } = false;

        // --- Relationships & Foreign Keys ---

        [Required(ErrorMessage = "Please select a matching product category.")]
        [Display(Name = "Category")]

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } = string.Empty;

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? Seller { get; set; }
    }
}
