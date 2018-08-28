using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string BookTitle { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }

        public OrderDetailsDto()
        {

        }

        public OrderDetailsDto(OrderDetails orderDetails)
        {
            Id = orderDetails.Id;
            OrderId = orderDetails.Order.Id;
            BookId = orderDetails.Book.Id;
            Price = orderDetails.Price;
            Quantity = orderDetails.Quantity;
            BookTitle = orderDetails.Book.Title;
        }
    }
}
