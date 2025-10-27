using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv7
{
    internal interface IKeyValuePair<TKey, TValue>
    {
        TKey Key { get; }
        TValue Value { get; }
    }
}
