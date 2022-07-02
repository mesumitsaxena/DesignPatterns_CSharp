using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Prototype.OptimizedRegistryApproach
{
    public class BirdSanctuary
    {
        public List<Bird> children;
        public List<string> parent;
        BirdRegistry birdRegistry;
        public BirdSanctuary()
        {
            children = new List<Bird>();
            parent = new List<string>();
            birdRegistry = new BirdRegistry();
        }
        public void ManageBirdSanctuary()
        {
            Bird bird = new Bird();
            bird.Name = "Bird 1";
            bird.Type = "Bird";
            bird.weight = 10;
            bird.Color = "Yellow";

            Sparrow longLeggedsparrow = new Sparrow();
            longLeggedsparrow.Name = "longLeggedsparrow";
            longLeggedsparrow.Type = "Sparrow";
            longLeggedsparrow.weight = 10;
            longLeggedsparrow.Color = "Brown";
            longLeggedsparrow.LegSize = 10;

            Crow sweetSoundcrow = new Crow();
            sweetSoundcrow.Name = "sweetSoundcrow";
            sweetSoundcrow.Type = "Crow";
            sweetSoundcrow.weight = 10;
            sweetSoundcrow.Color = "Black";
            sweetSoundcrow.Sound = "Kaw";

            // register birds using bird registry
            birdRegistry.CreateBird("longLeggedsparrow", longLeggedsparrow);
            birdRegistry.CreateBird("sweetSoundcrow", sweetSoundcrow);
            birdRegistry.CreateBird("bird", bird);

            parent.Add("bird");
            parent.Add("sweetSoundcrow");
            parent.Add("longLeggedsparrow");

            foreach(string birdtype in parent)
            {
                // This will create a copy from bird registry and store it in list
                children.Add(birdRegistry.getCopy(birdtype));
            }

        }
        
    }
   
}
