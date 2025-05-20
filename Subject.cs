
using Examination.Que;
using System;
using System.Collections.Generic;
using System.Linq;
using Examination;
using Examination_System.Exams;

namespace Examination_System
{
    internal class Subject
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Qlist Questions { get; set; }

        public Subject(string name, string code, string filePath)
        {
            Name = name;
            Code = code;
            Questions = new Qlist(filePath); 
        }



        public Exam CreateExam(string type, int timeInMinutes, int numberOfQuestions)
        {
            if (Questions == null || Questions.Count == 0)
                throw new Exception($"No questions found for subject: {Name}");

            if (numberOfQuestions > Questions.Count)
                throw new Exception("Number of questions requested exceeds available questions.");

            // to random Q

            List<Questions> GetRandomQuestions(List<Questions> allQuestions, int numberOfQuestions)
            {

                var rnd = new Random();

                var selected = new List<Questions>();

                var copy = new List<Questions>(allQuestions); 

                for (int i = 0; i < numberOfQuestions && copy.Count > 0; i++)
                {
                    int index = rnd.Next(copy.Count); 

                    selected.Add(copy[index]);      
                    
                    copy.RemoveAt(index);             
                }

                return selected;
            }

            var selectedQuestions = GetRandomQuestions(Questions, numberOfQuestions);


           
            Qlist selectedQlist = new Qlist(""); 

            foreach (var q in selectedQuestions)
                selectedQlist.AddWithoutLogging(q); 

            if (type.ToLower() == "final")
                return new FinalExam(timeInMinutes, numberOfQuestions, this, selectedQlist);
            else if (type.ToLower() == "practical")
                return new PracticalExam(timeInMinutes, numberOfQuestions, this, selectedQlist);
            else
                throw new Exception("Invalid exam type. Use 'final' or 'practical'.");
        }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }
    }
}
