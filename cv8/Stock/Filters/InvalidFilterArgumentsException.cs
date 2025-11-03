using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Filters
{
    public class InvalidFilterArgumentsException : Exception
    {
        public string Message { get; set; }

        public InvalidFilterArgumentsException(string message) : base(message) {}
    }
}
