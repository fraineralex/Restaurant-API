using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Models
{
    public class Order : AuditableBE
    {
        public int TableId { get; set; }
        public Table Table { get; set; }

        public List<Plate> Plates { get; set; }

        public double Total { get; set; }

        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }


    }
}
