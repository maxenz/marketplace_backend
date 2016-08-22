using Microsoft.AspNet.Identity.EntityFramework;
using Shaman.MarketPlace.Domain.DTOS;
using System.Data.Entity;

namespace Shaman.MarketPlace.Data.Configuration.EntityFramework
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {

        public AuthContext()
            : base("Shaman.MarketPlace")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
    }
}
