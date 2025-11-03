using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Filters
{
    public class WidthFilter : IFilter
    {
        public double? MinWidth { get; set; }
        public double? MaxWidth { get; set; }

        public bool IsMatch(IProduct item)
        {
            if (MinWidth == null && MaxWidth == null) throw new InvalidFilterArgumentsException("Min and Max is missing");

            if (item is IPhysicalProduct prod)
            {
                bool result = true;
                if (MinWidth.HasValue)
                {
                    if (prod.Width < MinWidth) result = false;
                }
                if (MaxWidth.HasValue)
                {
                    if (prod.Width > MaxWidth) result = false;
                }

                return result;
            }
            else return false;
        }
    }
}
