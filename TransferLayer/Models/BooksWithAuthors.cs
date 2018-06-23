using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    public class BooksWithAuthors
    {
        public AuthorDto Author { get; set; }

        public BookDto Book { get; set; }
    }
}
