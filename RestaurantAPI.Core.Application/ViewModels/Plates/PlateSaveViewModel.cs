using RestaurantAPI.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModels.Plates
{
    public class PlateSaveViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ForHowManyPeople { get; set; }

        public List<int> Ingredinets { get; set; }


        public int PlateCategoryId { get; set; }
        public PlateCategory PlateCategory { get; set; }
    }
}
