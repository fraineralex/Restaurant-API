using RestaurantAPI.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Domain.Models
{
    public class Plate: AuditableBE
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ForHowManyPeople { get; set; }

        public ICollection<Ingredient> Ingredinets { get; set; }


        public int PlateCategoryId { get; set; }
        public PlateCategory PlateCategory { get; set; }

    }
}
