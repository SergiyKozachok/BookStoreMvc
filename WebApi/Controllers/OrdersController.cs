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
    public class OrdersController : ApiController
    {
        private readonly OrderService _ordersService = new OrderService();

        public List<OrderDto> Get()
        {
            return _ordersService.GetAll();
        }

       
        public IHttpActionResult Get(int id)
        {
            OrderDto order = _ordersService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        
        public IHttpActionResult PostOrder(OrderDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ordersService.Add(order);

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        
        public IHttpActionResult PutOrder(int id, OrderDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ordersService.Update(id, order);
            return StatusCode(HttpStatusCode.NoContent);
        }

        
        public IHttpActionResult DeleteOrder(int id)
        {
            _ordersService.Remove(id);
            return Ok();
        }
    }
}
