using System;
using System.Collections.Generic;

namespace Hello
{
    class GradeBook
    {
        public GradeBook()
        {
            grades = new List<float>();
        }
        public void AddGrade(float grade)
        {
            if (grade < 0 || grade > 100) { Console.WriteLine("Out Of Bounds, Bud"); }
            grades.Add(grade);
            CalculateStatistics();
        }

        List<float> grades;
        public float TopGrade;
        public float BottomGrade;
        public float NumberOfGrades;

        public void CalculateStatistics()
        {
            TopGrade = 7;
            BottomGrade = 0;
            NumberOfGrades = grades.Count;

        }
    }
}
