using PlaceOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrder.Repository
{
    public class PlaceOrderRepository:IPlaceOrderRepository
    {
        private readonly OrderDbContext _context;
        public PlaceOrderRepository(OrderDbContext context)
        {
            this._context = context;
        }
        public  async Task<OrderDetails> PlaceOrder(MedicineViewModel model)
        {
            OrderDetails order = new OrderDetails { MedId = model.Id,MedName=model.Name,Amount=model.Cost, };
            _context.OrderList.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        
    }
}
