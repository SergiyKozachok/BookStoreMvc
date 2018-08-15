using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TransferLayer.Models;

namespace Mvc.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Pages").Result;
            var pagesList = response.Content.ReadAsAsync<IEnumerable<PageDto>>().Result;
            return View(pagesList);
        }

        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditPage(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Pages/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<PageDto>().Result);
        }

        [HttpPost]
        public ActionResult AddPage(PageDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string slug;

            PageDto dto = new PageDto();

            dto.Title = model.Title;

            if (string.IsNullOrWhiteSpace(model.Slug))
            {
                slug = model.Title.Replace(" ", "-").ToLower();
            }
            else
            {
                slug = model.Slug.Replace(" ", "-").ToLower();
            }

            dto.Slug = slug;
            dto.Title = model.Title;
            dto.Body = model.Body;
            dto.HasSidebar = model.HasSidebar;
            dto.Sorting = 100;

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Pages", model).Result;
            TempData["SuccessMessage"] = "You have added a new page!";
            return RedirectToAction("AddPage");
        }

        [HttpPost]
        public ActionResult EditPage(PageDto page)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Pages/" + page.Id, page).Result;
            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult PageDetails(int id)
        {
            HttpResponseMessage response =
                GlobalVariables.WebApiClient.GetAsync("Pages/" + id.ToString()).Result;

            if (response == null)
            {
                return Content("The page not exist");
            }
            //dto = new PageDto(response);



            return View(response.Content.ReadAsAsync<PageDto>().Result);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Pages/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void ReorderPages(int[] id)
        {
            int count = 1;
            PageDto dto;
            foreach (var pageId in id)
            {
                HttpResponseMessage response =
                    GlobalVariables.WebApiClient.GetAsync("Pages/" + id.ToString()).Result;
                dto = response.Content.ReadAsAsync<PageDto>().Result;
                dto.Sorting = count;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Pages", dto).Result;
                count++;
            }
        }
    }
}