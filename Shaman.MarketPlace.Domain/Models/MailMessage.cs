namespace Shaman.MarketPlace.Domain.Models
{
   public class MailMessage : Message
    {
        public MailMessage() : base()
        {
            this.MessageType = MessageTypes.Mail;
        }
    }
}
