using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = float.MaxValue;
            LowestGrade = float.MinValue;

        }

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        public static float MaximumGrade = 100;
        public static float MinimumGrade = 0;
    }


}
