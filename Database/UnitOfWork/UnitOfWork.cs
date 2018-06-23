using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Database.Repositories;

namespace Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly DatabaseContext _context = new DatabaseContext();
        private GenericRepository<Author> _authorRepository;
        private GenericRepository<Book> _bookRepository;


        public GenericRepository<Author> AuthorRepository => _authorRepository ?? (_authorRepository = new GenericRepository<Author>(_context));
        public GenericRepository<Book> BookRepository => _bookRepository ?? (_bookRepository = new GenericRepository<Book>(_context));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
