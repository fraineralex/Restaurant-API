using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.ViewModels.Table
{
    public class TableSaveViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HowManyInTable { get; set; }
        public string Description { get; set; }


        public int StatusId { get; set; }
    }
}
