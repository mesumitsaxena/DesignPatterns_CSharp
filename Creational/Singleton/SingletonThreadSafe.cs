using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Singleton
{
    internal class SingletonThreadSafe
    {
        //we are async keyword, by which each thread will come in this method one by one, so there will no
        // issue with thread creating multiple objects
        // static instance reference which can be accessed within class
        private static SingletonThreadSafe instance = null;
        //Restricting class to create instances
        private SingletonThreadSafe()
        {

        }

        public async static Task<SingletonThreadSafe> getInstance()
        {
            // for the first instance, if it is null, create a new instance
            if (instance == null)
            {
                instance = new SingletonThreadSafe();
            }
            //return the static instance which will be same for the application
            return instance;
        }
    }
    // Issue with this is we are async keyword on the method it self so whenever multiple thread comes to this method.
    // they will execute one by one.
    // By this our performance will reduce and there is no point of having multithreading if they are executing one by one.
  
}
