using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var countBetterStudents = 0;
            foreach(var student in Students)
            {
                if(student.AverageGrade > averageGrade)
                {
                    countBetterStudents++;
                }
            }

            var betterStudentsPercentage = (double)countBetterStudents / Students.Count * 100;

            switch(betterStudentsPercentage)
            {
                case var _ when betterStudentsPercentage < 20.0:
                    return 'A';
                case var _ when betterStudentsPercentage < 40.0:
                    return 'B';
                case var _ when betterStudentsPercentage < 60.0:
                    return 'C';
                case var _ when betterStudentsPercentage < 80.0:
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}
