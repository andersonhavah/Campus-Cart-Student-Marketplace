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
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        [Display(Name = "Listing Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a detailed description of the item's condition.")]
        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please specify a price.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be a positive value between $0.01 and $10,000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Product Image URL")]
        public string? ImageUrl { get; set; } = "images/placeholder.png";

        [Required]
        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        public bool IsSold { get; set; } = false;

        // --- RELATIONAL DATABASE FOREIGN KEYS & NAVIGATION PROPERTIES ---

        [Required(ErrorMessage = "Please select a matching product category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } = string.Empty;

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? Seller { get; set; }
    }
}