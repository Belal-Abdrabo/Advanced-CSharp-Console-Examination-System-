using Examination;
using Examination.Que;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_System.Exams
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int timeInMinutes, int numberOfQuestions, Subject subject, Qlist questionList)
            : base(timeInMinutes, numberOfQuestions, subject, questionList)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine($"\nPractical Exam - {Subject.Name}");
            Console.WriteLine($"Time: {timeInMinutes} minutes");
            Console.WriteLine($"Number of Questions: {numberOfQuestions}");
            Console.WriteLine("--------------------------------------------\n");

            int totalScore = 0;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Questions question = questionList[i];
                Console.WriteLine($"\nQ{i + 1}: {question.Body} ({question.Mark} marks)");

                // Print answers
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine($"{answer.Index}- {answer.AnswerBody}");
                }

                if(question.QHeader == Header.ChooseAll) { Console.Write("Your answer (comma-separated if multiple): ");}
                else { Console.Write("Your answer:  ");}

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

                

                Console.WriteLine(" Correct answer: ");

                //dispaly correct answer

                foreach (var correct in question.CorrectAnswers)
                {
                    Console.WriteLine($"- {correct.Index}. {correct.AnswerBody}");
                }

                // Calculate score with calling has wrong answer function
                bool isCorrect = selectedAnswers.Count == question.CorrectAnswers.Count && HasWrongAnswer(selectedAnswers, question.CorrectAnswers);

                if (isCorrect)
                {
                    totalScore += question.Mark;
                    Console.WriteLine(" Your answer is correct.");
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect.");
                }

                Console.WriteLine("--------------------------------------------");
            }


            int totalMarks = 0;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                totalMarks += questionList[i].Mark;
            }
            Console.WriteLine($" Exam finished. Your score: {totalScore}/{totalMarks}");
        }
    }
}
