using Mvc.Models;
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
            //foreach (var item in booksList)
            //{
            //    if (item.Image != null)
            //    {
            //        Base64ToImage(item.Image);
            //    }
            //}
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
            return RedirectToAction("Index");
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
    }
}