using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TransferLayer.Models;
using static Mvc.GlobalVariables;

namespace Mvc.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            HttpResponseMessage response = WebApiClient.GetAsync("Books").Result;
            var booksList = response.Content.ReadAsAsync<IEnumerable<BookDto>>().Result;
            return View(booksList);
        }

        public ActionResult AdmIndex()
        {
            HttpResponseMessage response = WebApiClient.GetAsync("Books").Result;
            var booksList = response.Content.ReadAsAsync<IEnumerable<BookDto>>().Result;
            return View(booksList);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            var model = new BookDto();
            var responseAth = WebApiClient.GetAsync("Authors").Result;
            var ahtList = responseAth.Content.ReadAsAsync<IEnumerable<AuthorDto>>().Result;
            var authorDtos = ahtList as AuthorDto[] ?? ahtList.ToArray();
            model.Authors = authorDtos.Select(a => new SelectListItemViewModel
            {
                Id = a.Id,
                Text = a.FirstName + " " + a.LastName
            }).ToList();

            HttpResponseMessage responseCtgr = WebApiClient.GetAsync("Categories").Result;
            var ctgrList = responseCtgr.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;
            var ctgrDtos = ctgrList as CategoryDto[] ?? ctgrList.ToArray();
            model.Categories = ctgrList.Select(c => new SelectCategoryListItemViewModel
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();

            if (id == 0)
            {
                return View(model);
            }

            var response = WebApiClient.GetAsync("Books/" + id).Result;
            model = response.Content.ReadAsAsync<BookDto>().Result;
            model.Authors = authorDtos.Select(a =>
            {
                var viewModel = new SelectListItemViewModel
                {
                    Id = a.Id,
                    Text = a.FirstName + " " + a.LastName
                };
                return viewModel;
            }).ToList();
            model.Categories = ctgrDtos.Select(a =>
            {
                var viewModel = new SelectCategoryListItemViewModel()
                {
                    Id = a.Id,
                    Title = a.Title
                };
                return viewModel;
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrEdit(BookDto book)
        {
            var file = Request.Files["image1"];

            if (file != null)
            {
                var sourceimage = System.Drawing.Image.FromStream(file.InputStream);
                book.Image = ImageToBase64(sourceimage, ImageFormat.Jpeg);
            }

            HttpResponseMessage responseAth = WebApiClient.GetAsync("Authors").Result;
            var ahtList = responseAth.Content.ReadAsAsync<IEnumerable<AuthorDto>>().Result;
            book.Authors = ahtList.Select(a => new SelectListItemViewModel
            {
                Id = a.Id,
                Text = a.FirstName + " " + a.LastName
            }).ToList();
            HttpResponseMessage responseCtgr = WebApiClient.GetAsync("Categories").Result;
            var ctgrList = responseCtgr.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;
            book.Categories = ctgrList.Select(c => new SelectCategoryListItemViewModel
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();
            if (book.Id == 0)
            {
                HttpResponseMessage response = WebApiClient.PostAsJsonAsync("Books", book).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = WebApiClient.PutAsJsonAsync("Books/" + book.Id, book).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("AddOrEdit");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = WebApiClient.DeleteAsync("Books/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public string ImageToBase64(Image image,
            System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
                imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public ActionResult Details(int id)
        {
            var response = WebApiClient.GetAsync("Books/" + id).Result;
            var model = response.Content.ReadAsAsync<BookDto>().Result;
            HttpResponseMessage responseAuthor = WebApiClient.GetAsync("Authors").Result;
            var authorList = responseAuthor.Content.ReadAsAsync<IEnumerable<AuthorDto>>().Result;
            foreach (var item in authorList)
            {
                if (item.Id == model.AuthorId)
                {
                    model.AuthorName = item.FirstName;
                    model.AuthorLastName = item.LastName;
                }
            }

            HttpResponseMessage responseCtgr = WebApiClient.GetAsync("Categories").Result;
            var ctgrList = responseCtgr.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;
            foreach (var item in ctgrList)
            {
                if (item.Id == model.CategoryId)
                {
                    model.CategoryName = item.Title;
                }
            }
            
            return View(model);
        }

        public ActionResult CategoryMenuPartial()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            var categoriesList = response.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;
            return PartialView(categoriesList);
        }

        public ActionResult ViewCategory(string name)
        {
            HttpResponseMessage responseBooks = WebApiClient.GetAsync("Books").Result;
            List<BookDto> booksList = responseBooks.Content.ReadAsAsync<IEnumerable<BookDto>>().Result.ToList();
            for (int i = 0; i < booksList.Count; i++)
            {
                if (booksList[i].CategoryName != name)
                {
                    booksList.Remove(booksList[i]);
                }
            }
            return View("Category");
        }
    }
}