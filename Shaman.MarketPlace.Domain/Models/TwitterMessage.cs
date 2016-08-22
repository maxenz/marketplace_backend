namespace Shaman.MarketPlace.Domain.Models
{
   public class TwitterMessage : Message
    {
        public TwitterMessage() : base()
        {
            this.MessageType = MessageTypes.Twitter;
        }
    }
}
