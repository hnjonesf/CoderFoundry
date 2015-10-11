using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class GradeBook
    {
        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <=100)
            {
                grades.Add(grade);
            }
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0f;
            foreach (float grade in grades)
            {
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            stats.HighestGrade = grades.Max();
            stats.LowestGrade = grades.Min();

            return stats;
        }

        public static float NextFloat(Random random)
        {
            float NextGrade = new float();
            double mantissa = (random.NextDouble());
            NextGrade = (float)(100 * mantissa);
            return NextGrade;
        }

        List<float> grades = new List<float>();
        public static float MinimumGrade = 0;
        public static float MaximumGrade = 100;
    }
}
