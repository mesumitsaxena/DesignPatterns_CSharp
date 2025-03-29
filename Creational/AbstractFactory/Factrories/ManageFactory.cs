using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Factory
{
    public class ManageFactory
    {
        public IPayrollFactory getFactory(string type)
        {
            switch(type)
            {
                case "FullTime": return new FullTimeFactory();
                case "Contractor": return new ContractorFactory();
                default: return null;
            }
        }
    }
}
