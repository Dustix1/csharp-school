using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Filters
{
    public class WheelCountFilter : IFilter
    {
        public int WheelCount { get; set; }
        public bool IsMatch(IProduct item)
        {
            if (item is IWheeledVehicle prod)
            {
                return prod.WheelCount == WheelCount;
            }
            else return false;
        }
    }
}
