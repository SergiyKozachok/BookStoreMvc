using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TransferLayer.Models;

namespace Mvc.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<BookDto> booksList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Books").Result;
            booksList = response.Content.ReadAsAsync<IEnumerable<BookDto>>().Result;
            return View(booksList);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            var model = new BookDto();
            IEnumerable<AuthorDto> ahtList;
            HttpResponseMessage responseAth = GlobalVariables.WebApiClient.GetAsync("Authors").Result;
            ahtList = responseAth.Content.ReadAsAsync<IEnumerable<AuthorDto>>().Result;
            model.Authors = ahtList.Select(a => new SelectListItemViewModel
            {
                Id = a.Id,
                Text = a.FirstName + " " + a.LastName
            }).ToList();
            if (id == 0)
            {
                return View(model);
            }
            else
            {
                
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Books/" + id.ToString()).Result;
                model = response.Content.ReadAsAsync<BookDto>().Result;
                model.Authors = ahtList.Select(a => new SelectListItemViewModel
                {
                    Id = a.Id,
                    Text = a.FirstName + " " + a.LastName
                }).ToList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(BookDto book)
        {
            IEnumerable<AuthorDto> ahtList;
            HttpResponseMessage responseAth = GlobalVariables.WebApiClient.GetAsync("Authors").Result;
            ahtList = responseAth.Content.ReadAsAsync<IEnumerable<AuthorDto>>().Result;
            book.Authors = ahtList.Select(a => new SelectListItemViewModel
            {
                Id = a.Id,
                Text = a.FirstName + " " + a.LastName
            }).ToList();
            if (book.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Books", book).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Books/" + book.Id, book).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Books/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}