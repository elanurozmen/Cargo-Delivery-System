using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kargoTakip
{
    public class Courier
    {
        public string courierName { get; set; }
        public string password { get; set; }
        public Location loc { get; set; }


    }
   public class Location
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}
