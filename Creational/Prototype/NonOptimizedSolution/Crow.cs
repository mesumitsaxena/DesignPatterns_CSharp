using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.NonOptimizedSolution
{
    internal class Crow:Bird
    {
        public string Sound { get; set; }
        public override Bird clone()
        {
            Crow copy = new Crow();
            copy.Color = this.Color;
            copy.Name = this.Name;
            copy.weight = this.weight;
            copy.Sound = this.Sound;
            return copy;
        }
    }
}
