using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TransferLayer.Models
{
    public class BookDto
    {
        public BookDto() { }

        public BookDto(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Price = book.Price;
            Count = book.Count;
            Image = book.Image;
            AuthorId = book.AuthorId;
            AuthorName = book.Author.firstName;
            AuthorLastName = book.Author.lastName;
            Description = book.Description;
            CategoryId = book.Category.Id;
            CategoryName = book.Category.Title;
        }

        public int Id { get; set; }

        public String Title { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorLastName { get; set; }

        public string Description { get; set; }

        public String Image { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public HttpPostedFileBase ImageUpload  { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


        


        public List<SelectListItemViewModel> Authors { get; set; }

        public List<SelectCategoryListItemViewModel> Categories { get; set; }

    }
}
