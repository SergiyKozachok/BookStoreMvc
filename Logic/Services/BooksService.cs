﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public List<BookDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.BookRepository.GetAll().Select(x => new BookDto(x)).ToList();
            }
        }

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
                    Image = book.Image,
                    AuthorId = book.AuthorId,
                    Description = book.Description,
                    CategoryId = book.CategoryId,
                };

                uow.BookRepository.Insert(bookDb);
                uow.SaveChanges();
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
                    Price = getBook.Price,
                    Image = getBook.Image,
                    AuthorId = getBook.AuthorId,
                    Description = getBook.Description,
                    CategoryId = getBook.CategoryId
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
                    Image = book.Image,
                    AuthorId = book.AuthorId,
                    Description = book.Description,
                    CategoryId = book.CategoryId
                };
                uow.BookRepository.Update(bookDb);
                uow.SaveChanges();
            }
        }

        public bool BookExists(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.BookRepository.Count(e => e.Id == id) > 0;
            }
        }
    }
}