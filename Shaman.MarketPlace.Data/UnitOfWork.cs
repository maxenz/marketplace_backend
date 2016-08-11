using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Models;
using Shaman.MarketPlace.Models.Models;
using System;
using System.Threading.Tasks;

namespace Shaman.MarketPlace.Data
{
    public class UnitOfWork : IDisposable
    {
        #region Properties

        private readonly MarketPlaceDbContext _context;

        #endregion

        #region Constructors
        public UnitOfWork()
        {
            _context = new MarketPlaceDbContext();
        }

        public UnitOfWork(MarketPlaceDbContext context)
        {
            _context = context;
        }

        #endregion

        #region General Methods
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Articles Repository

        private Repository<Article> _articleRepository;

        public Repository<Article> ArticleRepository
        {
            get { return _articleRepository ?? (_articleRepository = new Repository<Article>(_context)); }
        }

        #endregion

        #region Tickets Repository
        private Repository<Ticket> _ticketRepository;
        public Repository<Ticket> TicketRepository
        {
            get { return _ticketRepository ?? (_ticketRepository = new Repository<Ticket>(_context)); }
        }
        #endregion

        #region Users Repository

        private AuthRepository _userRepository;

        public AuthRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new AuthRepository()); }
        }

        #endregion

    }
}