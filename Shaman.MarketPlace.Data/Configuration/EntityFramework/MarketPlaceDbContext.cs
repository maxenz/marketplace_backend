using Shaman.MarketPlace.Domain.DTOS;
using Shaman.MarketPlace.Domain.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Shaman.MarketPlace.Data.Configuration.EntityFramework
{
    public class MarketPlaceDbContext : DbContext
    {

        #region Constructors

        public MarketPlaceDbContext()
    : base("Shaman.MarketPlace")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        static MarketPlaceDbContext()
        {
            Database.SetInitializer(new DbInitializer());

        }

        #endregion

        #region General Methods

        private void SetDateProperties()
        {
            var now = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Property("ModifiedDate").CurrentValue = now;
                if (entry.State == EntityState.Added) entry.Property("CreatedDate").CurrentValue = now;
            }
        }

        public override int SaveChanges()
        {
            SetDateProperties();
            return base.SaveChanges();
        }

        public override System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            SetDateProperties();
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Article>().Property(a => a.CreatedDate).HasColumnType("datetime2").HasPrecision(0);
            //modelBuilder.Entity<Article>().Property(a => a.ModifiedDate).HasColumnType("datetime2").HasPrecision(0);
            //modelBuilder.Entity<Article>().Property(a => a.PublishedDate).HasColumnType("datetime2").HasPrecision(0);
        }

        #endregion

        #region DbSets
        public DbSet<Case> Cases { get; set; }

        public DbSet<Message> Messages { get; set; }

        #endregion

    }
}