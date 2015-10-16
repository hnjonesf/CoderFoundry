using System;
using System.Speech.Synthesis;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {

            SpeechSynthesizer synth = new SpeechSynthesizer();
            DateTime date = new DateTime();
            date = date.AddDays(54);
            synth.Speak("Hi, Greatest Programmer ever"+date.DayOfWeek);

            GradeBook book = new GradeBook();
            book.AddGrade(93f);
            book.AddGrade(88f);
            book.AddGrade(99.4f);
            book.AddGrade(73.333f);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine("Highest: "+stats.HighestGrade);
            Console.WriteLine("Lowest: "+stats.LowestGrade);
            Console.WriteLine("Average: "+stats.AverageGrade);
            Console.ReadLine();
        }
    }
}
