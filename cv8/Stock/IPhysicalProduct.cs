using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    internal interface IPhysicalProduct : IProduct
    {
        double Height { get; }
        double Length { get; }
        double Width { get; }
    }
}
