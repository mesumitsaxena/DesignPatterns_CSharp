using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Singleton
{
    // Instead of managing the code for multithreading, we also have a solution which can create a instance
    // just before all the initialization happen.
    internal class SingletonEagerLoading
    {
        //Initilizing the instance eagerly before constructor also.
        // So when first time class will be loading into memory, this will inilize the instance
        private static SingletonEagerLoading instance = new SingletonEagerLoading();
        private SingletonEagerLoading() { }
        public static SingletonEagerLoading getInstance()
        {
            // As outside world will have the access to this method only, they will call this method to get the instance.
            return instance;
        }
    }
    // Issue with this is, this is not recommended, suppose we wanted to initiaze some properties of the class using constructors
    // then we might not be able to that that, how can we initize the properties using constructor as we are not calling constructor from outside?
    // we might pass the argument from getInstance and then if the instance is null while creating the instance pass the values in constructor here in singleton class
    // So eager loading is not recommended
}
