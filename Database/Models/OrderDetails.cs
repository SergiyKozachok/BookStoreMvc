using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }
    }
}
