using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
