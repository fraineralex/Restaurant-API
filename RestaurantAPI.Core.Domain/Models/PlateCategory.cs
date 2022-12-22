using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Models
{
    public class PlateCategory : AuditableBE
    {
        public string Name { get; set; }

        public ICollection<Plate> Plates { get; set; }
    }
}
