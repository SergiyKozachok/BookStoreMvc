using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Repositories;

namespace Database.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Author> AuthorRepository { get; }
        GenericRepository<Book> BookRepository { get; }
        GenericRepository<Page> PageRepository { get; }
        GenericRepository<Sidebar> SidebarRepository { get; }
        GenericRepository<Category> CategoryRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<OrderBooks> OrderBooksRepository { get; }

        void SaveChanges();
    }
}
