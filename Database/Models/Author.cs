using System;
using System.Collections.Generic;

namespace Database.Models
{
    public class Author
    {
        public int Id { get; set; }

        public String firstName { get; set; }

        public String lastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}