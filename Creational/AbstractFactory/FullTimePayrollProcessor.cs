using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class FullTimePayrollProcessor : IPayrollProcessor
    {
        public void processPayroll()
        {
            Console.WriteLine("Processing fulltime payroll processor");
        }
    }
}
