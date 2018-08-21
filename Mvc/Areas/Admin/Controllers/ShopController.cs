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
    }
}