using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Domain.Models;
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

        #region Cases Repository
        private Repository<Case> _caseRepository;
        public Repository<Case> CaseRepository
        {
            get { return _caseRepository ?? (_caseRepository = new Repository<Case>(_context)); }
        }
        #endregion

        #region Messages Repository
        private Repository<Message> _messageRepository;
        public Repository<Message> MessageRepository
        {
            get { return _messageRepository ?? (_messageRepository = new Repository<Message>(_context)); }
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