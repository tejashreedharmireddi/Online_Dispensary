using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceOrder.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public int MedId { get; set; }
        public string MedName { get; set; }
        public int Amount { get; set; }
        public string Address { get; set; }

    }
}
