## Singleton Design Pattern:
Ensuring at max only one instance of a class can be created ever.

**Why do we need such scenario?**

Let’s understand with this scenario- 

Suppose we have multiple services connected with the database

![image](https://user-images.githubusercontent.com/83850703/176428000-cc8be195-5da7-40bc-bfed-b6d87281f65a.png)

In order to connect with the database, services needs instances of database, so do we need instances for all services?
No. We can take once instance of database and all services can use it, it is because all services will be interacting with single db only.

**What if we create multiple objects of DB?**

- We can still create multiple objects of DB, but creating an object of DB is a costly operation.
- When we create an object of DB, basically we are making a connection DB, creating connection pools, connecting to URL with userId, password (Authentication will also happen).
- So, creating multiple object will be a costly operation. Also we need not need a different state, we need a same state of DB so that is why creating multiple objects are not required.
- That is why we can use single object of a class.

**How can we force a class to create only single instance?**

-	By making the class Static.

**What are the issues if we create the class as Static?**
-	Static classes don’t support inheritance.
-	Suppose we want implement few methods from interface, then we might not be able to do that with static classes but we can do it with normal class.
-	A Static Class cannot be extended whereas a singleton class can be extended.
-	A Static Class cannot be initialized whereas a singleton class can be.
-	A Static class is loaded automatically by the CLR when the program containing the class is loaded.
-	
Detailed example: [Link](https://stackoverflow.com/questions/2969599/why-use-singleton-instead-of-static-class)

**Other Option (Private Constructor) -**
-	We can force a class to not create an Instance of the object at all, How? 
-	By making the constructor private.
-	But by this how can we create an object?
-	If we have private constructor then we can still create object of the class with that class
-	We will create an object of the class within the class and expose the instance with a public method.

### Implementation:
**Two things to take care –**

1.	Creating a private static Instance, which will be created only once, and by static it will be available within application, why private? if we make it public, outside world can directly access this instance and modify the instance (create a new instance and store it in this reference).
```
private static Singleton_Normal instance = null;
```
2.	Static public method, so that we can return the instance to outside world. By making this method static, we will be able to call this method with the class name and no object needs to be created.
```
public static Singleton_Normal getInstance()
{
    		// for the first instance, if it is null, create a new instance
    		if (instance == null)
    		{
        		instance = new Singleton_Normal();
    		}
    	  //return the static instance which will be same for the application
    	  return instance;
}
```

### Ways to Implement Singleton:

- Normal Implementation (Without multithreading support)
- Singleton with multithreading support (Async method way)
- Singleton with eager loading
- Singleton with multithreading support (single lock)
- Singleton with multithreading support (double lock check)

**1.)	Normal Implementation (Without multithreading support):**

![image](https://user-images.githubusercontent.com/83850703/176430095-2ebacce5-d5c6-4894-9f37-931bdd7b391c.png)

**Issue with this:**
-	In multithreading environment, this is not thread safe.
-	Suppose thread 1 and thread2 land on line 26, both will execute line 28, which will give two instances, 
-	Example: thread 1 comes and thread 2 came into the method at same time, instance value will be null for both of them
-	Now thread 1 will execute and new instance will be given to instance ref.
-	Thread 2 will also execute line 28 and execute that line., now thread 1 returns the instance and thread 2 will return diff instance
-	So this is not thread safe.

**2.) Singleton with multithreading support (Async method way):**
![image](https://user-images.githubusercontent.com/83850703/176430304-0a2debaf-05c3-4a2b-b79c-ae3af6c547e0.png)

Asynchronously means one after another, Synchronous means parallel.
Async keyword is used in C# to enable Asynchronous programming, by making a method as async, it means if two threads are trying to access this method at same time, they will go one by one. 

**Issue with this:** 
-	Issue with this is we are using async keyword on the method itself so whenever multiple thread comes to this method.
-	By this our performance will reduce and there is no point of having multithreading if they are executing one by one. 

**3.) Singleton with eager loading:**

Instead of managing the code for multithreading, we also have a solution which can create a instance just before all the initialization happen.
![image](https://user-images.githubusercontent.com/83850703/176430660-85f91151-d93d-421c-b3f2-03996bae2e97.png)

**Issue with this:**
-	Issue with this is, this is not recommended, suppose we wanted to initialize some properties of the class using constructors
-	Then we might not be able to that that, how can we initialize the properties using constructor as we are not calling constructor from outside?
-	we might pass the argument from getInstance and then if the instance is null while creating the instance pass the values in constructor here in singleton class
-	So eager loading is not recommended.

**4.) Singleton with multithreading support (single lock):**

Here Instead of locking (using async) the whole method, just lock the portion of the code which is creating the new object.
![image](https://user-images.githubusercontent.com/83850703/176431407-832dcc6a-3f40-40e8-97ae-e1fe34518e1d.png)

**Issue with this is-**
-	if two thread T1 and T2 reach to (instance==null) they will both get into the code block and suppose T1 took a lock and created an instance, T2 was waiting outside, when T1 is finished T2 will also take a lock and create an another object which will break our principle.

**5.) Singleton with multithreading support (double lock check):**
From this method, check if(instance==null) twice, so that after lock if T1 creates the object, t2 will be notified that instance is not null so don’t create another object.

![image](https://user-images.githubusercontent.com/83850703/176431659-ec4ff288-0810-46ee-b2fb-2409c2660c3f.png)











