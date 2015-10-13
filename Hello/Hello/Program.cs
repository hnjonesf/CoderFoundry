using System;
using System.Speech.Synthesis;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook myGradeBook = new GradeBook();
            GradeBook myOtherGradeBook = new GradeBook();
            GradeBook myFirstBookAgain = myGradeBook;

            myGradeBook.AddGrade(55);
            myGradeBook.AddGrade(65);
            myGradeBook.AddGrade(75);
            myGradeBook.AddGrade(85);
            myGradeBook.AddGrade(95);

            myOtherGradeBook.AddGrade(100);
            myFirstBookAgain.AddGrade(99);

            Console.WriteLine(myGradeBook.NumberOfGrades);
            Console.WriteLine(myOtherGradeBook.NumberOfGrades);
            Console.ReadLine();

        }
    }
}
