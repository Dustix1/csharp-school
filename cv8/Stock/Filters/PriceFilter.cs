using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Filters
{
    public class PriceFilter : IFilter
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }

        public bool IsMatch(IProduct item)
        {
            if (MinPrice == null && MaxPrice == null) throw new InvalidFilterArgumentsException("Min and Max is missing");

            bool result = true;
            if (MinPrice.HasValue)
            {
                if (item.Price < MinPrice) result = false;
            }
            if (MaxPrice.HasValue)
            {
                if (item.Price > MaxPrice) result = false;
            }

            return result;
        }
    }
}
