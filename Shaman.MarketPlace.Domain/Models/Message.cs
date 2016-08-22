using Microsoft.AspNet.Identity.EntityFramework;
using Shaman.MarketPlace.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shaman.MarketPlace.Domain.Models
{
    public abstract class Message : IContent
    {
        #region Properties 

        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string Content { get; set; }

        public MessageTypes MessageType { get; set; }

        //[ForeignKey("Id")]
        //public virtual Case Case { get; set; }

        //[ForeignKey("Id")]
        //public virtual IdentityUser SentBy { get; set; }

        //[ForeignKey("Id")]
        //public virtual IdentityUser AnsweredBy { get; set; }

        #endregion

        #region Constructors 

        public Message ()
        {

        }

        #endregion

    }
}
