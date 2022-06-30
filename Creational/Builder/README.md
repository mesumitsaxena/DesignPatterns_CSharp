## Builder Design Pattern
Builder Design pattern is a creational design pattern in which builder class is creating an object of other class due to excessive parameters, validation of parameters or having immutable objects.
*When to use Builder Design Pattern:*
-	When we have many attributes  or
-	When we have to validate the attributes before creating the object or
-	Immutable objects
*Requirement:*
-	Suppose we have many attributes and parameters in the class.
-	Before creating the object, we want to validate those attributes.

*Lets understand how a class will look like if we have many parameters:*
Suppose we have an user exam class, we would be having many attributes, like science marks,  hindi marks, English marks, maths marks etc.
```
Class UserExam{
	Int Science;
	Int English;
	Int hindi;
	Int maths;
}
```
While creating the object of the class, we would have to pass these parameters in the constructor of the class in order to initialize the attributes of the class and create an object.
Suppose we create an object like below-
```
UserExam userExam= new UserExam(70,80,60,76);
```
*Issue with above approach:*
From above code, are you able to figure out marks of which subject? Do you know 70 are English marks or hindi marks? No
So above way has below cons:
-	*Unreadable Code:* while reading the code are you able to figure out parameter values?
-	*Prone to Errors:* While passing the marks, it is possible that we can pass hindi marks in science or vice versa because we don’t know from constructor what to pass?

Also, suppose we want to only create an object with English marks or English and Maths marks or any other combination, what can we do?
 We can create constructor overloading right?
Example: 
-	UserExam(int eng, int hindi)	
-	UserExam(int maths, int science)
-	UserExam(int eng);
-	UserExam(int end, int hindi)
-	UserExam(int maths, science, int hindi) etc..

Some implementation if above methods would be-
```
UserExam{
	UserExam(int maths, int English){
	This.English=English;
	This.maths=maths;
	}
	UserExam(int maths, int English, int science){
	This(maths,English);
	This.Science=science;
	}
}
```
In the above constructor UserExam(int maths, int English, int science) we used this(maths,English), this is called *Telescoping Constructor(Constructor which is internally calling another constructor)*
*Issue with above method:*
-	Telescoping Constructor- They are anti pattern and not recommended
-	Because of multiple constructor, we might not be able to call correct constructor because of signature match. Example: if we want to call UserExam(10,30), how do you know which constructor is called? Is it UserExam(int maths, int science) or UserExam(int end, int hindi).
-	Still Unreadable code
*Another Approach (Hashmap):*
Suppose we create a constructor with map with string and int like below-
```
UserExam(Map<string,int> Parameters)
```
Here string is subject name and int is marks
Example:
```
HashMap<string,int> map= new HashMap<string,int>();
Map.Add(“Hindi”,70);
Map.Add(“English”, 90);
Map.Add(“Maths”, 98);
UserExam userExam= new UserExam(Map);
```
So by this we will be able to create the object without any ambiguity.
*Benefits:*
-	Readable code – we are adding marks with their subjects in map, so code is readable
-	Not probing to error – As code is readable, then not proning to error as we adding the correct values with subjects.
*Issues with this approach:*
-	Suppose we have few more parameters, example: Name (string type), Attendance(double type) etc
-	We have our map with only int as values, above parameters are of type string and double.
*Another Approach:*
So map is not working, think of something which works like a Map. Which allows you to have multiple values and each value can be of multiple types and can be identified via its name. Answer is class.

Ans is *Class*
So in class we can have multiple parameters of different types and its object can have multiple values. We can say it’s a parameter class.
 
```
internal class UserExamParameter
{
    public int englishMarks;
    public int mathsMarks;
    public int scienceMarks;
    public String name;
}
```
**Now before moving forward, let’s focus on second requirement, which is validate the input before creating object**
* Before creating the object, we want to validate those attributes:*
-	Suppose our requirement is if any of the marks are greater than 100, we should not create an object and return an exception saying, marks are not valid.
-	Suppose maths + English marks should not be more than 150, then object should not be created.
-	Else provide all the marks to userexam class and create the object.
-	One can say, we can validate the parameters or variables using getter and setter properties.
-	But when we call getter and setter for a particular parameter, our object is already created, but requirement is if parameters are not valid then don’t create the object.
Let’s implement above requirement in UserExam class-
```
internal class UserExam
{
    private int englishMarks;
    private int mathsMarks;
    private int scienceMarks;
    private String name;
    public UserExam(UserExamParameter parameter)
    {
        if(parameter.englishMarks>100 || parameter.mathsMarks>100 || parameter.scienceMarks > 100)
        {
            throw new InvalidDataException("Marks are invalid");
        }
        if (parameter.englishMarks + parameter.mathsMarks > 150)
        {
            throw new InvalidDataException("English+Maths should not be greater than 150");
        }
        if (parameter.name.StartsWith("0"))
        {
            throw new InvalidDataException("Name should not start with 0");
        }
        this.englishMarks = parameter.englishMarks;
        this.mathsMarks = parameter.mathsMarks;
        this.scienceMarks = parameter.scienceMarks;
        this.name = parameter.name;
    }
    public double average()
    {
        double average = (this.mathsMarks + this.scienceMarks + this.englishMarks) / 3;
        return average;
    }
}
```
In the above code we can see, if any of the marks are violating the validation, we are throwing error and not initializing the parameters.
Lets see, how it will work with client class-
```
public static void Main(string[] args)
{
    UserExamParameter userExamParameter = new UserExamParameter();
    userExamParameter.name = "Sumit";
    userExamParameter.mathsMarks = 60;
    userExamParameter.scienceMarks = 101;
    userExamParameter.englishMarks = 45;

    UserExam userExam;
    try
    {
        userExam = new UserExam(userExamParameter);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
```
So in the above example, we can see, userexamparameter class providing all the data to user exam class and user exam class is then validating and allowing the client to create the object.
**Impovements**
Right now userExamParameter class is only providing the data to userExam, what if userexamparameter class is able to perform below activity –
-	Have all the attribute of userExam.
-	Validate the attribute of userExam
-	Create an object of userExam.
If userExamParameter is able to fulfill above activities, then we can say userExamParameter class is fully equipped to create an object of userExam and if userExamParameter is building userExam, the userExamParameter is a builder class, so we can say it is userExamBuilder.
Also, Suppose UserExam class is immutable, means we can set the values of UserExam outside world, Also we can’t create an object of userExam, then how will be get the instance and set the values of userExam.
Answer is using userExambuilder.
Below is the code:
```
internal class UserExam
{
    private int englishMarks;
    private int mathsMarks;
    private int scienceMarks;
    private String name;
    //private constructor, so can not create an object of this class outside world.
    private UserExam(){}
    //we need the builder object in order to set the values of builder class
    public static UserExamBuilder getBuilder()
    {
        return new UserExamBuilder();
    }
    public class UserExamBuilder
    {
        private int englishMarks;
        private int mathsMarks;
        private int scienceMarks;
        private String name;
        //return builder object inorder to perform method chaining
        public UserExamBuilder setEnglishMarks(int englishMarks)
        {
            this.englishMarks = englishMarks;
            return this;
        }
        //return builder object inorder to perform method chaining
        public UserExamBuilder setmathsMarks(int mathsMarks)
        {
            this.mathsMarks = mathsMarks;
            return this;
        }
        //return builder object inorder to perform method chaining
        public UserExamBuilder setscienceMarks(int scienceMarks)
        {
            this.scienceMarks = scienceMarks;
            return this;
        }
        //return builder object inorder to perform method chaining
        public UserExamBuilder setname(string name)
        {
            this.name = name;
            return this;
        }
        public UserExam build()
        {
            if (this.englishMarks > 100 || this.mathsMarks > 100 || this.scienceMarks > 100)
            {
                throw new InvalidDataException("Marks are invalid");
            }
            if (this.englishMarks + this.mathsMarks > 150)
            {
                throw new InvalidDataException("English+Maths should not be greater than 150");
            }
            if (this.name.StartsWith("0"))
            {
                throw new InvalidDataException("Name should not start with 0");
            }
            //we are able to create object if this class here, because userExamBuilder exist within userExam
            UserExam userExam = new UserExam();
            userExam.englishMarks = this.englishMarks;
            userExam.mathsMarks = this.mathsMarks;
            userExam.scienceMarks = this.scienceMarks;
            userExam.name = this.name;
            return userExam;
        }

    }
```
Builder class is inside the userExam class, that is why it is able to create object of userExam and return the object of it.
So in this, immutable object userExam is able to set and create the object using builder class.
Below is client class code:
```
//This is called method chaining
UserExam userExam = UserExam.getBuilder()
                            .setEnglishMarks(99)
                            .setscienceMarks(67)
                            .setname("Sumit")
                            .build();

```
