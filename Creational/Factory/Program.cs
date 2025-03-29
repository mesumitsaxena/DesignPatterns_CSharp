// See https://aka.ms/new-console-template for more information
using FactoryPattern;
using FactoryPattern.Factory;


PayrollFactory factory = new PayrollFactory();
var processor = factory.GetPayrollProcessor("Contractor");
processor.ProcessPayroll();
