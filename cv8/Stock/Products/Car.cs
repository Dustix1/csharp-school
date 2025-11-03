using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Products
{
    public class Car : IPhysicalProduct, IWheeledVehicle
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }

        public int WheelCount { get; set; }
    }
}
