using System;
using System.Collections.Generic;
using System.Linq;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class MessageService
    {
        private readonly List<Message> _mockMessages = new();

        public bool SendMessage(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Content)) return false;

            message.Id = _mockMessages.Count + 1;
            message.Timestamp = DateTime.UtcNow;
            _mockMessages.Add(message);
            return true;
        }

        public List<Message> GetUserInbox(string userId)
        {
            return _mockMessages.Where(m => m.ReceiverUserId == userId)
                                .OrderByDescending(m => m.Timestamp)
                                .ToList();
        }
    }
}