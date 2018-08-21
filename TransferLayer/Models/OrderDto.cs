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

        public OrderDto()
        {

        }
    }
}
