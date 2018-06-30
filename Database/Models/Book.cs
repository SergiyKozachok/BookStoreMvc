using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Book
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public String Image { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}