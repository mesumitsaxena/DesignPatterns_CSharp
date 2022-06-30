using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Builder.Approach_2
{
    internal class Client
    {
        public static void Main(string[] args)
        {
            UserExam userExam = UserExam.getBuilder()
                                        .setEnglishMarks(99)
                                        .setscienceMarks(67)
                                        .setname("Sumit")
                                        .build();
           
        }
    }
}
