using PlaceOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrder.Repository
{
    public interface IPlaceOrderRepository
    {
        public Task<OrderDetails>  PlaceOrder(MedicineViewModel model);
    }
}
