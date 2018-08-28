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
        private GenericRepository<Page> _pageRepository;
        private GenericRepository<Sidebar> _sidebarRepository;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<Order> _orderRepository;
        private GenericRepository<OrderDetails> _orderDetailsRepository;


        public GenericRepository<Author> AuthorRepository => 
            _authorRepository ?? (_authorRepository = new GenericRepository<Author>(_context));

        public GenericRepository<Book> BookRepository => 
            _bookRepository ?? (_bookRepository = new GenericRepository<Book>(_context));

        public GenericRepository<Page> PageRepository =>
            _pageRepository ?? (_pageRepository = new GenericRepository<Page>(_context));

        public GenericRepository<Sidebar> SidebarRepository =>
            _sidebarRepository ?? (_sidebarRepository = new GenericRepository<Sidebar>(_context));

        public GenericRepository<Category> CategoryRepository =>
            _categoryRepository ?? (_categoryRepository = new GenericRepository<Category>(_context));

        public GenericRepository<Order> OrderRepository =>
            _orderRepository ?? (_orderRepository = new GenericRepository<Order>(_context));

        public GenericRepository<OrderDetails> OrderDetailsRepository =>
            _orderDetailsRepository ?? (_orderDetailsRepository = new GenericRepository<OrderDetails>(_context));

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

