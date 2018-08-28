using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Order
    {
        public Order()
        {
            this.Books = new HashSet<Book>();
        }

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
        
        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
