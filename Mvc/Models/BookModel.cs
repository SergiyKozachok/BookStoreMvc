using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

    }
}