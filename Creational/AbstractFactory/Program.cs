// See https://aka.ms/new-console-template for more information
using AbstractFactoryPattern;
using AbstractFactoryPattern.Factory;

Console.WriteLine("Hello, World!");

var manageFactory = new ManageFactory();
var factory = manageFactory.getFactory("Contractor");

var system = new PayrollSystem(factory);
system.runPayroll();
