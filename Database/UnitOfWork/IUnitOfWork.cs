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

        void SaveChanges();
    }
}
