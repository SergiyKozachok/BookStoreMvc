using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using System.Data.Entity;


namespace Database.Repositories
{
    public class BookRepository
    {
        internal DatabaseContext Context;
        internal DbSet<Book> DbSet;

        public BookRepository(DatabaseContext context)
        {
            Context = context;
            DbSet = context.Set<Book>();
        }

        //public List<Book> SortBooksByCategory(string name)
        //{
        //    List<Book> booksList;

        //    Category category = Context.Categories.Where(x => x.Title == name).FirstOrDefault();
        //    int catId = category.Id;

        //    booksList = Context.Books.ToArray().Where(x => x.CategoryId == catId).Select(x => new Book(x)).ToList();

        //}
    }
}
