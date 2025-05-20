using Examination;
using Examination.Que;
using Examination_System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination
{
    internal class FinalExam : Exam
    {
        public FinalExam(int timeInMinutes, int numberOfQuestions, Subject subject, Qlist questionList)
            : base(timeInMinutes, numberOfQuestions, subject, questionList){}

        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam - {Subject.Name}");
            Console.WriteLine($"\n Time: {timeInMinutes} minutes");
            Console.WriteLine($"\n Number of Questions: {numberOfQuestions}");
            Console.WriteLine("------------------------------------------------\n");

            int totalScore = 0;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Questions question = questionList[i];
                //display the Q
                Console.WriteLine($"\nQ{i + 1}: {question.Body}    ({question.Mark} marks)");
                //display answers
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine($"{answer.Index}. {answer.AnswerBody}");
                }
                if(question.QHeader == Header.ChooseAll)
                {
                    Console.Write("\nYour answer (comma-separated if multiple): ");
                }
                else
                {
                    Console.Write("\nYour answer: ");

                }

                string input = Console.ReadLine();

                List<AnswersC> selectedAnswers = new List<AnswersC>();
                if (question.QHeader == Header.ChooseAll)
                {
                    int[] indices = input.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
                    selectedAnswers = GetAnswers(indices, question);
                }
                else
                {
                    int index = int.Parse(input.Trim());
                    selectedAnswers = GetAnswers(index, question);
                }

                QuestionAnswer.Add(question, selectedAnswers);



                Console.WriteLine("------------------------------------------------\n");
            }
            //end of Questions 

            //start to check answers

            //to chech he choose correct answers

            foreach (var entry in QuestionAnswer)
            {
                var question = entry.Key;
                var answers = entry.Value;

                bool isCorrect = (answers.Count == question.CorrectAnswers.Count) && HasWrongAnswer(answers, question.CorrectAnswers);


                if (isCorrect)
                {
                    totalScore += question.Mark;
                }
            }
            //to calculate exam marks 
            int totalMarks = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                totalMarks += questionList[i].Mark;
            }

            Console.WriteLine($"\nExam finished. Your score: {totalScore}/{totalMarks}");
        }
    }
}
