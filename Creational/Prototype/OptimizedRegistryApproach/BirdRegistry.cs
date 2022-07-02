using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.OptimizedRegistryApproach
{
    public class BirdRegistry
    {
        private Dictionary<string, Bird> registry;
        public BirdRegistry()
        {
            registry = new Dictionary<string, Bird>();
        }
        public void CreateBird(string Name, Bird bird)
        {
            registry.Add(Name, bird);
        }
        public Bird getCopy(string Name)
        {
            return registry[Name].clone();
        }
    }
}
