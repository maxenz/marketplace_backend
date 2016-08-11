using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Models;
using System.Data.Entity;

namespace Shaman.MarketPlace.Data.Configuration
{
    public class DbInitializer : DropCreateDatabaseAlways<MarketPlaceDbContext>
    {
        protected override void Seed(MarketPlaceDbContext context)
        {
            //UnitOfWork uow = new UnitOfWork(context);

            //uow.ArticleRepository.Insert(new Article { Body = "<p>Heyo content!</p>", Title = "Title" , Ignored = "NOT OUTPUTTEDEDED"});
            //uow.SaveChanges();
        }
    }
}