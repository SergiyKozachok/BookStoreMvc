﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Models
{
    public class Book
    {
        public Book()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public String Title { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public String Image { get; set; }

        public String Description { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}