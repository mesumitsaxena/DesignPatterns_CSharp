using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class ContractorTaxFormGenerator : ITaxFormGenerator
    {
        public void GenerateTaxForm()
        {
            Console.WriteLine("Generating T4A forms for Contractor");
        }
    }
}
