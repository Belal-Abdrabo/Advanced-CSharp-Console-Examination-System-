using Examination_System;

namespace Examination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject programingSubject = new Subject("Programing", "CS101", @"E:\ITI\Full stack .net\c#\Assignments\code\QL2.txt");
            Subject mathSubject = new Subject("Math", "MATH101", @"E:\ITI\Full stack .net\c#\Assignments\code\QL.txt");

            try
            {
                Console.WriteLine("=== Practical Exam ===");
                Exam practicalExam = mathSubject.CreateExam("practical", 30, 3);
                practicalExam.ShowExam();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            //try
            //{
            //    Console.WriteLine("\n=== Final Exam ===");
            //    Exam finalExam = programingSubject.CreateExam("final", 45, 3);
            //    finalExam.ShowExam();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
            Console.WriteLine("\n You did good thanks");
            Console.ReadKey();
        }
    }
}
