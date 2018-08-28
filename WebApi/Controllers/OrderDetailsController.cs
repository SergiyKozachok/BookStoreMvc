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
    public class OrderDetailsController : ApiController
    {
        private readonly OrderDetailsService _orderDetailsService = new OrderDetailsService();

        public List<OrderDetailsDto> Get()
        {
            return _orderDetailsService.GetAll();
        }


        public IHttpActionResult Get(int id)
        {
            OrderDetailsDto orderDetails = _orderDetailsService.GetById(id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }


        public IHttpActionResult PostOrderDetails(OrderDetailsDto orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _orderDetailsService.Add(orderDetails);

            return CreatedAtRoute("DefaultApi", new { id = orderDetails.OrderId }, orderDetails);
        }


        public IHttpActionResult PutOrderDetails(int id, OrderDetailsDto orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _orderDetailsService.Update(id, orderDetails);
            return StatusCode(HttpStatusCode.NoContent);
        }


        public IHttpActionResult DeleteOrderDetails(int id)
        {
            _orderDetailsService.Remove(id);
            return Ok();
        }
    }
}
