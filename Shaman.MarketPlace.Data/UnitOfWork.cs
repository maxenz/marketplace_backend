﻿using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Models;
using System;
using System.Threading.Tasks;

namespace Shaman.MarketPlace.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly BoilerplateDbContext _context;

        public UnitOfWork()
        {
            _context = new BoilerplateDbContext();
        }

        public UnitOfWork(BoilerplateDbContext context)
        {
            _context = context;
        }

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

        private Repository<Article> _articleRepository;

        public Repository<Article> ArticleRepository
        {
            get { return _articleRepository ?? (_articleRepository = new Repository<Article>(_context)); }
        }
    }
}