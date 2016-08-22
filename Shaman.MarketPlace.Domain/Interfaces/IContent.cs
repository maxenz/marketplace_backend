using System;

namespace Shaman.MarketPlace.Domain.Interfaces
{
    public interface IContent
    {
        int Id { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime? PublishedDate { get; set; }
    }
}