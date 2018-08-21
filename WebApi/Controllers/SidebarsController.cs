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
    public class SidebarsController : ApiController
    {
        private readonly SidebarService _sidebarService = new SidebarService();

        // GET: api/Pages
        public List<SidebarDto> GetSidebars()
        {
            return _sidebarService.GetAll();
        }

        public IHttpActionResult GetSidebar(int id)
        {
            SidebarDto sidebar = _sidebarService.GetById(id);
            if (sidebar == null)
            {
                return NotFound();
            }

            return Ok(sidebar);
        }

        public IHttpActionResult PostSidebar(SidebarDto sidebar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _sidebarService.Add(sidebar);

            return CreatedAtRoute("DefaultApi", new { id = sidebar.Id }, sidebar);
        }

        public IHttpActionResult PutSidebar(int id, SidebarDto sidebar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _sidebarService.Update(id, sidebar);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteSidebar(int id)
        {
            _sidebarService.Remove(id);

            return Ok(1);
        }
    }
}
