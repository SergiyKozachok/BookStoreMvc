using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TransferLayer.Models;
using static Mvc.GlobalVariables;


namespace Mvc.Controllers
{
    public class ShoppingCartController : Controller
    {
        private string strCart = "Cart";

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Books/" + id.ToString()).Result;
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (Session[strCart] == null)
            {
                List<CartDto> lsCart = new List<CartDto>
                {
                    new CartDto(response.Content.ReadAsAsync<BookDto>().Result, 1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<CartDto> lsCart = (List<CartDto>) Session[strCart];
                int check = IsExistingCheck(id);
                if (check == -1)
                {
                    lsCart.Add(new CartDto(response.Content.ReadAsAsync<BookDto>().Result, 1));
                }
                else
                {
                    lsCart[check].Quantity++;
                }
                Session[strCart] = lsCart;
            }
            return View("Index");
        }

        private int IsExistingCheck(int? id)
        {
            List<CartDto> lsCart = (List<CartDto>) Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Book.Id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            int check = IsExistingCheck(id);
            List<CartDto> lsCart = (List<CartDto>) Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }

        public ActionResult UpdateCart(FormCollection form)
        {
            string[] quantities = form.GetValues("quantity");
            List<CartDto> listCart = (List<CartDto>) Session[strCart];
            for (int i = 0; i < listCart.Count; i++)
            {
                listCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }

            Session[strCart] = listCart;
            return View("Index");
        }

        public ActionResult CheckOut()
        {
            return View("CheckOut");
        }

        [HttpPost]
        public ActionResult ProcessOrder(FormCollection form)
        {
            List<CartDto> listCart = (List<CartDto>)Session[strCart];
            OrderDto order = new OrderDto()
            {
                CustomerName = form["cusName"],
                CustomerSurname = form["cusSurname"],
                CustomerPhone = form["cusPhone"],
                CustomerEmail = form["cusEmail"],
                CustomerAddress = form["cusAddress"],
                OrderDate = DateTime.Now,
                PaymentType = "Cash",
                Status = "Processing"
            };
            HttpResponseMessage responseOrder = GlobalVariables.WebApiClient.PostAsJsonAsync("Orders", order).Result;
            TempData["SuccessMessage"] = "Saved Successfully";

            foreach (CartDto cart in listCart)
            {
                OrderBooksDto orderBooks = new OrderBooksDto()
                {
                    Order_Id = 1,
                    Book_Id = cart.Book.Id,
                    Price = (int)cart.Book.Price,
                    Quantity = cart.Quantity
                };

                HttpResponseMessage responseOrderBooks = GlobalVariables.WebApiClient.PostAsJsonAsync("OrderBooks", orderBooks).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }


            Session.Remove(strCart);
            return View("OrderSuccess");
        }

        //[HttpPost]
        //public ActionResult ProcessOrderBooks(OrderDto order)
        //{
        //    List<CartDto> listCart = (List<CartDto>)Session[strCart];

            
        //}
    }
}