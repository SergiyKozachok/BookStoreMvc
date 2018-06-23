using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Database.Models;
using Logic.Services;
using TransferLayer.Models;

namespace WebApi.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly AuthorsService _authorsService = new AuthorsService();

        // GET: api/Authors
        public List<AuthorDto> GetAuthors()
        {
            return _authorsService.GetAll();
        }

        //// GET: api/Authors/5
        //[ResponseType(typeof(Author))]
        public IHttpActionResult GetAuthor(int id)
        {
            AuthorDto author = _authorsService.GetById(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        //// PUT: api/Authors/5
        //[ResponseType(typeof(void))]
        public IHttpActionResult PutAuthor(int id, AuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authorsService.Update(id, author);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //// POST: api/Authors
        //[ResponseType(typeof(Author))]
        public IHttpActionResult PostAuthor(AuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authorsService.Add(author);

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        //// DELETE: api/Authors/5
        //[ResponseType(typeof(Author))]
        public IHttpActionResult DeleteAuthor(int id)
        {
            _authorsService.Remove(id);


            return Ok(1);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool AuthorExists(int id)
        //{
        //    return db.Authors.Count(e => e.Id == id) > 0;
        //}
    }
}