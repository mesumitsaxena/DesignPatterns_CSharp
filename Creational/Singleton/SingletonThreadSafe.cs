using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Singleton
{
    internal class SingletonThreadSafe
    {
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
}
