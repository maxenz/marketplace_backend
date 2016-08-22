using Microsoft.AspNet.Identity.EntityFramework;
using Shaman.MarketPlace.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shaman.MarketPlace.Domain.Models
{
    public class Case : IContent
    {
        #region Properties

        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string Description { get; set; }

        public bool IsClosed { get; set; }

        public virtual List<Message> Messages { get; set; }

        //[ForeignKey("Id")]
        //public virtual IdentityUser CreatedBy { get; set; }

        #endregion

        #region Constructors 

        public Case()
        {
            this.Messages = new List<Message>();
        }

        #endregion
    }
}
