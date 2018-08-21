using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    public class CartDto
    {
        public BookDto Book { get; set; }

        public int Quantity { get; set; }

        public CartDto() { }

        public CartDto(BookDto book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }
    }
}
