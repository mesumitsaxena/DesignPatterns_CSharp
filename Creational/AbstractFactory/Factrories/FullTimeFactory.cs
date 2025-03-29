using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Factory
{
    public class FullTimeFactory : IPayrollFactory
    {
        public ITaxFormGenerator getFormGenerator()
        {
            return new FullTimeTaxFormGenerator();
        }

        public IPayrollProcessor getPayrollProcessor()
        {
            return new FullTimePayrollProcessor();
        }
    }
}
