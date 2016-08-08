using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Models;
using System.Data.Entity;

namespace Shaman.MarketPlace.Data.Configuration
{
    public class DbInitializer : DropCreateDatabaseAlways<BoilerplateDbContext>
    {
        protected override void Seed(BoilerplateDbContext context)
        {
            UnitOfWork uow = new UnitOfWork(context);

            uow.ArticleRepository.Insert(new Article { Body = "<p>Heyo content!</p>", Title = "Title" , Ignored = "NOT OUTPUTTEDEDED"});
            uow.SaveChanges();
        }
    }
}