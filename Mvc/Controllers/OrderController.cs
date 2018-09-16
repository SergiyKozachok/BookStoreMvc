using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TransferLayer.Models;

namespace Mvc.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Orders").Result;
            var ordersList = response.Content.ReadAsAsync<IEnumerable<OrderDto>>().Result;
            return View(ordersList);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Orders/" + id.ToString()).Result;
            var order = response.Content.ReadAsAsync<OrderDto>().Result;

            HttpResponseMessage orderDetailsResponse = GlobalVariables.WebApiClient.GetAsync("OrderDetails").Result;
            var orderDetailsList = orderDetailsResponse.Content.ReadAsAsync<IEnumerable<OrderDetailsDto>>().Result;
            foreach (var item in orderDetailsList)
            {
                if (item.Id == order.OrderDetailsId)
                {

                }
            }
            return View(order);
        }

        // GET: Order/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Order/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Order/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Order/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Order/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Order/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
