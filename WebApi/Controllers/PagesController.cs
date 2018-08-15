using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic.Services;
using TransferLayer.Models;

namespace WebApi.Controllers
{
    public class PagesController : ApiController
    {
        private readonly PageService _pageService = new PageService();

        // GET: api/Pages
        public List<PageDto> GetPages()
        {
            return _pageService.GetAll();
        }

        public IHttpActionResult GetPage(int id)
        {
            PageDto page = _pageService.GetById(id);
            if (page == null)
            {
                return NotFound();
            }

            return Ok(page);
        }

        public IHttpActionResult PostPage(PageDto page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pageService.Add(page);

            return CreatedAtRoute("DefaultApi", new { id = page.Id }, page);
        }

        public IHttpActionResult PutPage(int id, PageDto page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pageService.Update(id, page);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeletePage(int id)
        {
            _pageService.Remove(id);

            return Ok(1);
        }
    }
}
