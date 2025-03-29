using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class FullTimePayrollProcessor : IPayrollProcessor
    {
        public void ProcessPayroll()
        {
            Console.WriteLine("Processing Full time employee processor");
        }
    }
}
