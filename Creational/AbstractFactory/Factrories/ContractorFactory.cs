using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Factory
{
    internal class ContractorFactory : IPayrollFactory
    {
        public ITaxFormGenerator getFormGenerator()
        {
            return new ContractorTaxFormGenerator();
        }

        public IPayrollProcessor getPayrollProcessor()
        {
            return new ContractorPayrollProcessor();
        }
    }
}
