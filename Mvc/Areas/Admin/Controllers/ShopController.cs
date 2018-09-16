using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TransferLayer.Models;

namespace Mvc.Areas.Admin.Controllers
{
    public class ShopController : Controller
    {
        // GET: Admin/Shop/Categories
        public ActionResult Categories()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            var categoriesList = response.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;
            return View(categoriesList);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View(new CategoryDto());
        }

        [HttpGet]
        public ActionResult EditCategory(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<CategoryDto>().Result);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryDto ctgr)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Categories", ctgr).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            
            return RedirectToAction("AddCategory");
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryDto ctgr)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Categories/" + ctgr.Id, ctgr).Result;
            TempData["SuccessMessage"] = "Updated Successfully";

            return RedirectToAction("Categories");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Categories/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Categories");
        }
    }
}