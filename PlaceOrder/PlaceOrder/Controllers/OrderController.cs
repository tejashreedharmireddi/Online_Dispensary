using Microsoft.AspNetCore.Mvc;
using PlaceOrder.Models;
using PlaceOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPlaceOrderRepository _repo;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OrderController));
        public OrderController(IPlaceOrderRepository repo)
        {
            this._repo = repo;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MedicineViewModel model)
        {
            try
            {
                _log4net.Info("Order details are getting added");
                var obj = await _repo.PlaceOrder(model);
                return Ok(obj);

            }
            catch (Exception e)
            {
                _log4net.Error("Error in Adding Order Details");
                return new BadRequestObjectResult("order is not placed");
            }
        }
       

    }
}
