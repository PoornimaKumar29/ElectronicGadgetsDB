using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApp.exception
{
    public class TechShopException : Exception
    {
        public TechShopException(string message) : base(message) { }
        public TechShopException(string message, Exception innerException) : base(message, innerException) { }
    }
}
