using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_CSharp.Creational.Builder
{
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
}
