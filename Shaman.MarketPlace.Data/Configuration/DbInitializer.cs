using Microsoft.AspNet.Identity.EntityFramework;
using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Domain.DTOS;
using Shaman.MarketPlace.Domain.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Shaman.MarketPlace.Data.Configuration
{
    public class DbInitializer : DropCreateDatabaseAlways<MarketPlaceDbContext>
    {
        protected override void Seed(MarketPlaceDbContext context)
        {
            UnitOfWork uow = new UnitOfWork(context);
            insertUser(uow);
            //IdentityUser user = getUser(uow).Result;
            //Case _case = new Case() { Id = 1, CreatedBy = user, Description = "Caso de prueba" };
            //FacebookMessage fbMessage = new FacebookMessage() { SentBy = user, Content = "Contenido Facebook " };
            //TwitterMessage twMessage = new TwitterMessage() { SentBy = user, Content = "Contenido Twitter" };
            //_case.Messages.Add(fbMessage);
            //_case.Messages.Add(twMessage);

            //uow.CaseRepository.Insert(_case);

            uow.SaveChanges();
        }

        protected async void insertUser(UnitOfWork uow)
        {
            ApplicationUser appUser = new ApplicationUser() { UserName = "mpoggio", Password = "Maxo6142", ConfirmPassword = "Maxo6142", TuVieja = "sarasa" };
            await uow.UserRepository.RegisterUser(appUser);
        }

        //protected async Task<IdentityUser> getUser(UnitOfWork uow)
        //{
        //    IdentityUser user = await uow.UserRepository.FindUser("mpoggio", "Maxo6142");
        //    if (user != null) return user;

        //    return null;
        //}
    }
}