using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    public class BookDto
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }


        public BookDto() {  }

        public BookDto(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Price = book.Price;
            Count = book.Count;
            AuthorId = book.AuthorId;
        }


        public List<SelectListItemViewModel> Authors { get; set; }
    }
}
