using RestaurantAPI.Core.Domain.Common;
using System.Collections.Generic;

namespace RestaurantAPI.Core.Domain.Models
{
    public class Ingredient:AuditableBE
    {
        public string Name { get; set; }

        public ICollection<Plate> Plates { get; set; }
    }
}
