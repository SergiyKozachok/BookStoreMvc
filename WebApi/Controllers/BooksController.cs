using Database.Models;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TransferLayer.Models;

namespace WebApi.Controllers
{
    public class BooksController : ApiController
    {
        private readonly BooksService _booksService = new BooksService();

        // GET: api/Books
        public List<BookDto> Get()
        {
            return _booksService.GetAll();
        }

        // GET: api/Books/5
        //[ResponseType(typeof(Book))]
        public IHttpActionResult Get(int id)
        {
            BookDto book = _booksService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //// POST: api/Books
        //[ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _booksService.Add(book);

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        //// PUT: api/Books/5
        //[ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _booksService.Update(id, book);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //// DELETE: api/Books/5
        //[ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            _booksService.Remove(id);
            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool BookExists(int id)
        //{
        //    return db.Books.Count(e => e.Id == id) > 0;
        //}
    }
}
