using Mvc.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TransferLayer.Models;

namespace Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Authors").Result;
            var athList = response.Content.ReadAsAsync<IEnumerable<AuthorDto>>().Result;
            return View(athList);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new AuthorDto());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Authors/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<AuthorDto>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(AuthorDto ath)
        {
            if (ath.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Authors", ath).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Authors/" + ath.Id, ath).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Authors/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}