using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class OrderBooks
    {
        public int Order_Id { get; set; }

        public int Book_Id { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
