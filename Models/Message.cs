using System;
using System.ComponentModel.DataAnnotations;

namespace Campus_Cart_Student_Marketplace.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int ItemId { get; set; }

        // Navigation property so the message knows which product is being discussed
        public CartItem? Item { get; set; }

        [Required]
        public string SenderUserId { get; set; } = string.Empty;

        [Required]
        public string ReceiverUserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please type a message before sending.")]
        [StringLength(1000, ErrorMessage = "Messages cannot exceed 1000 characters.")]
        public string Content { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;
    }
}