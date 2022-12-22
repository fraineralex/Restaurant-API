using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public double Total { get; set; }
        public int OrderStatusId { get; set; }
    }
}
