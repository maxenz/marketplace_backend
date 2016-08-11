using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Shaman.MarketPlace.Models.Interfaces;
using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shaman.MarketPlace.Models
{
    public class Article : IContent
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        [Required]
        public string Title { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        [JsonIgnore]
        public string Ignored { get; set; }
    }
}