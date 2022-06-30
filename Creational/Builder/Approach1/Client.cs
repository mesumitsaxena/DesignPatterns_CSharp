using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Builder
{
    internal class Client
    {
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
    }
}
