using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class ContractorPayrollProcessor : IPayrollProcessor
    {
        public void processPayroll()
        {
            Console.WriteLine("Processing contractor payroll");
        }
    }
}
