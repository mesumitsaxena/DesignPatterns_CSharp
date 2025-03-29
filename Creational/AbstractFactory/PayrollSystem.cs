using AbstractFactoryPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class PayrollSystem
    {
        public IPayrollProcessor payrollProcessor;
        public ITaxFormGenerator taxFormGenerator;

        public PayrollSystem(IPayrollFactory payrollFactory)
        {
            payrollProcessor = payrollFactory.getPayrollProcessor();
            taxFormGenerator = payrollFactory.getFormGenerator();
        }

        public void runPayroll()
        {
            payrollProcessor.processPayroll();
            taxFormGenerator.GenerateTaxForm();
        }
    }
}
