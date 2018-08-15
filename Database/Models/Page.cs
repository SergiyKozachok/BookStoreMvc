using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Page
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Slug { get; set; }

        public String Body { get; set; }

        public int Sorting { get; set; }

        public bool HasSidebar { get; set; }


    }
}
