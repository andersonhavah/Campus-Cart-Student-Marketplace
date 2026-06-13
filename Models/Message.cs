using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campus_Cart_Student_Marketplace.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item? Item { get; set; }

        [Required]
        public string SenderUserId { get; set; } = string.Empty;

        [Required]
        public string ReceiverUserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please type a message before sending.")]
        [StringLength(1000)]
        public string Content { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;
    }
}