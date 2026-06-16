using Campus_Cart_Student_Marketplace.Data;
using Campus_Cart_Student_Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Campus_Cart_Student_Marketplace.Services
{
    public class MessageService
    {
        private readonly ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SendMessage(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Content))
                return false;

            message.Timestamp = DateTime.UtcNow;

            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            return true;
        }

        public List<Message> GetUserInbox(string userId)
        {
            return _context.Message
                .Where(m => m.ReceiverUserId == userId)
                .OrderByDescending(m => m.Timestamp)
                .ToList();
        }

        public List<Message> GetSentMessages(string userId)
        {
            return _context.Message
                .Where(m => m.SenderUserId == userId)
                .OrderByDescending(m => m.Timestamp)
                .ToList();
        }

        public async Task<bool> MarkAsRead(int messageId)
        {
            var message = await _context.Message.FindAsync(messageId);

            if (message == null) return false;

            message.IsRead = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMessage(int messageId)
        {
            var message = await _context.Message.FindAsync(messageId);

            if (message == null) return false;

            _context.Message.Remove(message);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}