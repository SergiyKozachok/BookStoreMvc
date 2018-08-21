using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    public class OrderBooksDto
    {
        public int Order_Id { get; set; }

        public int Book_Id { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public OrderBooksDto()
        {

        }

        public OrderBooksDto(OrderBooks orderBooks)
        {
            Order_Id = orderBooks.Order_Id;
            Book_Id = orderBooks.Book_Id;
            Price = orderBooks.Price;
            Quantity = orderBooks.Quantity;
        }
    }
}
