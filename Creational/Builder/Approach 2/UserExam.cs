using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Builder.Approach_2
{
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
    }
}
