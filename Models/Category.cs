using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Campus_Cart_Student_Marketplace.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        // Establishes that a category can have many items
        public List<Item> Items { get; set; } = new();
    }
}