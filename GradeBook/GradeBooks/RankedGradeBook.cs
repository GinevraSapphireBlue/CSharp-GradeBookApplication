using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (!VerifySufficientNumberOfStudents())
            {
                throw new InvalidOperationException();
            }

            var countBetterStudents = 0;
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    countBetterStudents++;
                }
            }

            var betterStudentsPercentage = (double)countBetterStudents / Students.Count * 100;

            switch (betterStudentsPercentage)
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

        private Boolean VerifySufficientNumberOfStudents()
        {
            return Students.Count >= 5;
        }

        public override void CalculateStatistics()
        {
            if(VerifySufficientNumberOfStudents())
            {
                base.CalculateStatistics();
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (VerifySufficientNumberOfStudents())
            {
                base.CalculateStudentStatistics(name);
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
        }


    }
}
