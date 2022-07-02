using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.OptimizedRegistryApproach
{
    public interface ICloneable<T>
    {
        public T clone();
    }
}
