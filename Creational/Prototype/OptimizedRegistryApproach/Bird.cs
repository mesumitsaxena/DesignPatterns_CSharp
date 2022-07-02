using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.OptimizedRegistryApproach
{
    public  class Bird:ICloneable<Bird>
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public int weight { get; set; }
        public string Type { get; set; }
        public Bird() { }
        public Bird(Bird old)
        {
            this.Name = old.Name;
            this.Type = old.Type;
            this.weight = old.weight;
            this.Color = old.Color;
        }

        public Bird clone()
        {
            // in clone of the bird, we will create new object and in constructor will pass, current object
            // as current object will act as old object to new object
            return new Bird(this);
        }
    }
}
