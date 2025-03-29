using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class FullTimeTaxFormGenerator : ITaxFormGenerator
    {
        public void GenerateTaxForm()
        {
            Console.WriteLine("Generating T4 Forms for FullTime Employees");
        }
    }
}
