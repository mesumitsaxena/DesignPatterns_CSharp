using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.NonOptimizedSolution
{
    public class BirdSanctuary
    {
        public List<Bird> children;
        public List<Bird> parent;
        public BirdSanctuary()
        {
            children = new List<Bird>();
            parent = new List<Bird>();
        }
        public void CreateBird(string type)
        {
            if (type == "Sparrow")
            {
                Sparrow bird = new Sparrow();
                bird.Name = "Intelligent Sparrow";
                bird.Type = "Sparrow";
                bird.Age = 2;
                bird.weight = 1;
                bird.LegSize = 2;
                bird.Color = "Brown";
                parent.Add(bird);
            }
            else if (type == "Crow")
            {
                Crow bird = new Crow();
                bird.Name = "Normal Crow";
                bird.Type = "Crow";
                bird.weight = 1;
                bird.Color = "Black";
                bird.Sound = "Kaw";
                parent.Add(bird);
            }
        }
        public List<Bird> reproduce(List<Bird> parent)
        {
            foreach (Bird child in parent)
            {
                children.Add(child.clone());
            }
            return children;
        }
        
    }
   
}
