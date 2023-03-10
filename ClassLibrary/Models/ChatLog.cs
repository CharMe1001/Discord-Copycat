using Discord_Copycat.Models.Base;

namespace Discord_Copycat.Models
{
    public class ChatLog : BaseEntity
    {
        public String Message { get; set; } = "";

        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
