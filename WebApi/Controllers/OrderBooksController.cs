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
    public class OrderBooksController : ApiController
    {
        private readonly OrderBooksService _orderBooksService = new OrderBooksService();

        public List<OrderBooksDto> Get()
        {
            return _orderBooksService.GetAll();
        }


        public IHttpActionResult Get(int id)
        {
            OrderBooksDto orderBooks = _orderBooksService.GetById(id);
            if (orderBooks == null)
            {
                return NotFound();
            }

            return Ok(orderBooks);
        }


        public IHttpActionResult PostOrderBooks(OrderBooksDto orderBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _orderBooksService.Add(orderBooks);

            return CreatedAtRoute("DefaultApi", new { id = orderBooks.Order_Id }, orderBooks);
        }


        public IHttpActionResult PutOrderBooks(int id, OrderBooksDto orderBooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _orderBooksService.Update(id, orderBooks);
            return StatusCode(HttpStatusCode.NoContent);
        }


        public IHttpActionResult DeleteOrder(int id)
        {
            _orderBooksService.Remove(id);
            return Ok();
        }
    }
}
