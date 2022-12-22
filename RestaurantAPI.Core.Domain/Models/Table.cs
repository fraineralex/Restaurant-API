using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Models
{
    public class Table: AuditableBE
    {
        public string Name { get; set; }
        public int HowManyInTable { get; set; }
        public string Description { get; set; }


        public int StatusId { get; set; }
        public TableStatus TableStatus { get; set; }

    }
}
