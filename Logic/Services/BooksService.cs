using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Database.UnitOfWork;
using Logic.Services.Interface;
using TransferLayer.Models;

namespace Logic.Services
{
    public class BooksService : IBooksService
    {
        public void Add(BookDto book)
        {
            using (var uow = new UnitOfWork())
            {
                Book bookDb = new Book()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    Count = book.Count,
                    AuthorId = book.AuthorId
                };

                uow.BookRepository.Insert(bookDb);
                uow.SaveChanges();
            }
        }

        public List<BookDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.BookRepository.GetAll().Select(x => new BookDto(x)).ToList();
            }
        }

        public BookDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getBook = uow.BookRepository.GetById(id);
                BookDto book = new BookDto()
                {
                    Id = getBook.Id,
                    Title = getBook.Title,
                    Count = getBook.Count,
                    Price = getBook.Price

                };
                return book;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Book book = uow.BookRepository.GetById(id);
                uow.BookRepository.Delete(book);
                uow.SaveChanges();
            }
        }

        public void Update(int id, BookDto book)
        {
            using (var uow = new UnitOfWork())
            {
                Book bookDb = new Book()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Count = book.Count,
                    Price = book.Price,
                    AuthorId = book.AuthorId
                };
                uow.BookRepository.Update(bookDb);
                uow.SaveChanges();
            }
        }
    }
}
