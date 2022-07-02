using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.OptimizedRegistryApproach
{
    public class Sparrow : Bird
    {
        public int LegSize { get; set; }
        public int Age { get; set; }
        public Sparrow()
        {

        }
        // this constructor will be used to set the properties of new object
        // by calling parent constructor (base(old)) we are actually deligating
        // the task of filling Bird's properties to Bird only
        public Sparrow(Sparrow old):base(old)
        {
            // and this class will only set properties of the own class
            this.LegSize = old.LegSize;
            this.Age = old.Age;
        }
        public  Bird clone()
        {
            // create new object and pass current object.
            // current object will be treated as old object in new object
            return new Sparrow(this);
        }
    }
}
