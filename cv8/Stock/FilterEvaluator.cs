using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    public class FilterEvaluator
    {
        private List<IFilter> filters = new List<IFilter>();

        public void Add(IFilter filter)
        {
            filters.Add(filter);
        }

        public bool IsMatch(IProduct item)
        {
            foreach (IFilter filter in filters)
            {
                if (!filter.IsMatch(item)) return false;
            }

            return true;
        }
    }
}
