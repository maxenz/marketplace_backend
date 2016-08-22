
namespace Shaman.MarketPlace.Domain.Models
{
    public class FacebookMessage : Message
    {
        public FacebookMessage() : base()
        {
            this.MessageType = MessageTypes.Facebook;
        }
    }
}
