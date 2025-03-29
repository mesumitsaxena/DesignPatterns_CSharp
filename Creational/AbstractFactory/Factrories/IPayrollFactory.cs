using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Factory
{
    public interface IPayrollFactory
    {
        public IPayrollProcessor getPayrollProcessor();
        public ITaxFormGenerator getFormGenerator();
    }
}
