using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.NonOptimizedSolution
{
    internal class Sparrow : Bird
    {
        public int LegSize { get; set; }
        public int Age { get; set; }
        public override Bird clone()
        {
            Sparrow copy = new Sparrow();
            copy.Color = this.Color;
            copy.Name = this.Name;
            copy.weight = this.weight;
            copy.LegSize = this.LegSize;
            copy.Age = this.Age;
            return copy;
        }
    }
}
