### Prototype Design Pattern
Prototype design pattern lets you create a clone/copy of current object.
**Let’s understand with a case study-**
Suppose we have to create Bird Sanctuary, which will have multiple birds of different types.
How will the bird sanctuary will look-
```
Class BirdSanctuary{
	Bird CreateBird(Bird original){
		Bird copy= new Bird();
		Copy.color=original.color;
		Copy.age=original.age;
		//etc
	}
}
```
**Issue with above Approach:**
- We might have different birds, like sparrow, crows etc. Considering all birds with only one class Bird and maintain all code within that will break SRP principal. 
- So, above method might not work, and we will have to create multiple subclasses.
## Approach 1 :
Considering we will create multiple subclasses and make Bird an abstract class
```
Abstract Class Bird{
//Attributes
//Methods
}
```
Suppose we have 2 Birds, Crow and Sparrow
```
Class Crow extends Bird{
//Few additional crow attributes
// Few additional crow methods
}
Class Sparrow extends Bird{
//Few additional Sparrow attributes
// Few additional Sparrow methods
}

```

We might have same bird’s (Crow or Sparrow) objects but with different properties like, we can have 5 crows or 6 sparrows in our bird sanctuary but those crows might have same or different attribute values.
Example: 1st crow might be named as Indian Cow, 2nd might be African Crow or their color might be different, like 1st crow is dark brown or 2nd crow might be full black.
Suppose we have to create 100 objects of sparrows, then creating 100 objects and set their attributes manually can be a tedious task. As we know in sparrow might be have almost same attribute values like legs, wings length etc, we can create one object and their create 99 copies/clone of that object and change attribute values if required. By this we are only changing few of attribute values of sparrows, which is better than creating and setting each value from scratch.
So, what we can do here is we can create a bird class (abstract or interface) and then create multiple subclasses as Crow, Sparrow, Penguin etc. 
Let’s understand if we don’t follow prototype DP, how a code would look like for Bird Sanctuary-
```
Class BirdSanctuary{
	List<Bird> Children;
List<Bird> CreateBird(List<Bird> original){
		For(Bird bird : original){
		   If(bird.type==”Crow”){
			Bird copy= Crow ();
			Copy.color=bird.color;
			// copy other attributes
			Children.Add(copy); 
		}
		   If(bird.type==”Sparrow”){
			Bird copy= sparrow();
			Copy.color=bird.color;
			// copy other attributes
			Children.Add(copy); 
		}
	}
	Return children;
}
```
**Issue with above approach:**
-	It is violating SRP. Creating a copy of bird having responsibility of multiple and different bird is not single responsibility.
-	It is violating Open/Closed Principal – in order to add/update or delete any bird, we will need to modify the bird sanctuary class. 
-	** There might be few private properties which can be exposed to outside world will not get copied and cloning of the object will not happen correctly**

## Approach 2 :
Instead giving responsibility to create a clone to Bird Sanctuary, best place to make a replica is their own object.
Object will have accessibility to even private fields inside their own object as well.
So, we will give a extra method in each class which will be called clone/copy.
Let’s see this in action –
 
Create an abstract method clone in Bird, so all the birds will have to implement it-
```
public abstract class Bird
{
    public string Color { get; set; }
    public string Name { get; set; }
    public int weight { get; set; }
    public abstract Bird clone();
}
```
Now create subclasses and implement clone method-
```
public class Crow:Bird
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
public class Sparrow : Bird
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
```
So each class has their own method to copy.
Let’s see how Bird Sanctuary class will behave-
```
public class BirdSanctuary
{
    public List<Bird> children;
    public BirdSanctuary()
    {
        children = new List<Bird>();
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
```
So we are able to create clone of object by just a method called clone().
This looks perfect right?
Now, let’s consider a method where we have to create original birds in Bird Sanctuary. In order to call above method reproduce, we already need List of original birds to make copies, right? For that lets create a method in Bird Sanctuary named CreateBird which will accept string parameter represents type of bird we want to create.
How would that method work? How will we create original birds? Let’s see –
```
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
```
What do you think about the Create Bird method?
**Issues with above Approach:**
-	SRP(Single Responsibility Principle) is violated
-	Open/Closed Principle is violated

## Approach 3 (Registry DP):
We have seen, we are able to create copy of the object efficiently but creating original objects is not efficient.
What is the use of creating an original object? We will create an object only once and then we can make multiple copies out of it right?
Here is the concept of Registry comes into picture. Using Registry DP, we will create an object and store it somewhere and whenever we need to create a copy of that object, we will get the object from storage and create copies of out of it.
Here few modification from previous logics – Suppose we are not aware about type of bird it is then we should create Bird’s object and set its basic attributes.
But we still wants all the classes to create method called clone, for that we can create an interface and that interface should implement in Bird class and all other subclasses are extending Bird class so, they can have their own implementation.
```
public interface ICloneable<T>
{
    public T Clone();
}
```
Now, in order to create an copy, we will have two constructors, one will be create normal object, and another to create clone, in another constructor we will pass old object and in constructor will copy of old object to new object.
Let’s see in action-
```
public  class Bird:ICloneable<Bird>
{
    public string Color { get; set; }
    public string Name { get; set; }
    public int weight { get; set; }
    public string Type { get; set; }
    // to create an object in bird sanctuary
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
// in clone of the bird, we will create new object and in constructor   will pass, current object
        // as current object will act as old object to new object
        return new Bird(this);
    }
}
```
We will have similar implementation of Crow and Sparrow, where we will have two constructor, one is to create an object and another to create a clone.
Why to do such complicated code? It will simplify our efforts and logic, how?
When we create a clone of sparrow or crow object, we don’t have to fill details of Bird. It is kind of solving SRP, previously, Crow and Sparrow were setting properties of bird object as well while copy, now each class will set their own property, Let’s see in action-
```
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
public class Crow:Bird
{
    public string Sound { get; set; }
    public Crow()
    {

    }
    // this constructor will be used to set the properties of new object
    // by calling parent constructor (base(old)) we are actually deligating
    // the task of filling Bird's properties to Bird only
    public Crow(Crow old):base(old)
    {
        // and this class will only set properties of the own class
        this.Sound = old.Sound;

    }
    public  Bird clone()
    {
        // create new object and pass current object.
        // current object will be treated as old object in new object
        return new Crow(this);
    }
}
```
Finally our Bird Sanctuary will look like this-
```
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
```


	







