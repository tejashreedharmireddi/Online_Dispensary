using MedicineMvcClient.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MedicineMvcClient.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [ValidateAntiForgeryToken]
        public  IActionResult PlacingOrder()
        {
            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }
            else
            {
                return View();
            }
        }
       [HttpPost]
        public async Task<IActionResult> PlacingOrder(OrderDetails d)
        {
            if (!ModelState.IsValid)
            {
                return View(d);
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44358");
            var jsonstring = JsonConvert.SerializeObject(d);
            var message = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Order/", message);
            if(response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var orderDetails = JsonConvert.DeserializeObject<OrderDetails>(jsonContent);
                ViewBag.Id = orderDetails.MedId;
                ViewBag.Name = orderDetails.MedName;
                return View("Successfully Ordered");


            }
            else
            {
                return RedirectToAction("PlacingOrder", "Order");
            }

           

        }
}
