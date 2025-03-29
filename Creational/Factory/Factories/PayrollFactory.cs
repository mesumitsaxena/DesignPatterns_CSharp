using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factory
{
    public class PayrollFactory
    {
        public IPayrollProcessor GetPayrollProcessor(string input)
        {
            switch(input)
            {
                case "FullTime": return new FullTimePayrollProcessor();
                case "Contractor": return new ContractorPayrollProcessor();
                default: return null;
            }
        }


    }
}
