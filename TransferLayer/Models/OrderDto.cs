using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; }

        public string PaymentType { get; set; }

        public string Status { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }

        public int OrderDetailsId { get; set; }

        public OrderDto(Order order)
        {
            Id = order.Id;
            OrderName = order.OrderName;
            OrderDate = order.OrderDate;
            PaymentType = order.PaymentType;
            Status = order.Status;
            CustomerName = order.CustomerName;
            CustomerSurname = order.CustomerSurname;
            CustomerPhone = order.CustomerPhone;
            CustomerEmail = order.CustomerEmail;
            CustomerAddress = order.CustomerAddress;
        }

        public Order GetEntity()
        {
            return new Order()
            {
                Id = Id,
                OrderName = OrderName,
                OrderDate = OrderDate,
                PaymentType = PaymentType,
                Status = Status,
                CustomerName = CustomerName,
                CustomerSurname = CustomerSurname,
                CustomerPhone = CustomerPhone,
                CustomerEmail = CustomerEmail,
                CustomerAddress = CustomerAddress
            };
        }

        public OrderDto()
        {

        }
    }

    //public class SelectOrderList
    //{
    //    public int Id { get; set; }

    //    public int Id { get; set; }

    //    public double Price { get; set; }

    //    public int Quantity { get; set; }

    //    public int Id { get; set; }

    //    OrderId = orderDetails.Order.Id;
    //    BookId = orderDetails.Book.Id;
    //    Price = orderDetails.Price;
    //    Quantity = orderDetails.Quantity;
    //    BookTitle = orderDetails.Book.Title;
    //}
}
