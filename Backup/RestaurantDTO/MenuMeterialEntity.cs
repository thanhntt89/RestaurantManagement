using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantDTO
{
   public class MenuMeterialEntity
    {
       public int MenuId { get; set; }
       public List<MeterialEntity> MenuMeterialEntityList = new List<MeterialEntity>();
    }

   public class MeterialEntity
   {
       public int MeterialId { get; set; }
       public double Quantity { get; set; }
   }
}
