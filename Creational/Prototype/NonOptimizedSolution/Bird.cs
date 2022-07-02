using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.NonOptimizedSolution
{
    public abstract class Bird
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public int weight { get; set; }
        public string Type { get; set; }
        public abstract Bird clone();
    }
}
