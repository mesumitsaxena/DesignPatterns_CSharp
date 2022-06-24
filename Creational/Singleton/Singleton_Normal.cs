using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Singleton
{
    // By Making private constructor, we are not allowing this class to make instances.
    // but how will be create instance of the class and that is only one instance of the class?
    // we can create attribute as instance of the class and initialize them in getInstance method which is public
    // by this method we expose the instance of the class to external world.
    internal class Singleton_Normal
    {
        // static instance reference which can be accessed within class
        private static Singleton_Normal instance = null;
        //Restricting class to create instances
        private Singleton_Normal()
        {

        }
        //public method which is exposed to external world, in order to access one and only one instance
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
    }
    //Issue with this?
    // in multithreading invironment, this is not thread safe.
    // suppose thead 1 and thread2 land on line 26, both will execute line 28, which will give two instances, 
    // example: thread 1 comes at line 26 thread 2 also comes at 26 at same time, instance value will be null for both of them
    // now thread 1 will execute and new instance will be given to instance ref.
    // thread 2 will also execute line 28 and execute that line., now thread 1 returns the instance and thread 2 will return diff instance
    // So this is not thread safe.
}
