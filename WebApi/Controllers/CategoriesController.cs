using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TransferLayer.Models;

namespace WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly CategoryService _categoryService = new CategoryService();

        // GET: api/Categories
        public List<CategoryDto> GetCategories()
        {
            return _categoryService.GetAll();
        }

        public IHttpActionResult GetCategory(int id)
        {
            CategoryDto category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        public IHttpActionResult PostCategory(CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Add(category);

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        public IHttpActionResult PutCategory(int id, CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Update(id, category);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteCategory(int id)
        {
            _categoryService.Remove(id);

            return Ok(1);
        }
    }
}
