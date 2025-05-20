using Examination;
using Examination.Que;
using Examination_System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination
{
    internal class Exam
    {
        protected int timeInMinutes;
        public int numberOfQuestions;
        public Subject Subject;
        public Qlist questionList;
        protected int score { get; set; } = -1;

        // Dictionary for Q and Answers
        public Dictionary<Questions, List<AnswersC>> QuestionAnswer { get; set; } = new Dictionary<Questions, List<AnswersC>>();

        public Exam(int timeInMinutes, int numberOfQuestions, Subject subject, Qlist questionList)
        {
            this.timeInMinutes = timeInMinutes;
            this.numberOfQuestions = numberOfQuestions;
            this.Subject = subject;
            this.questionList = questionList;
        }

        public Exam(int timeInMinutes, int numberOfQuestions, Subject subject)
        {
            this.timeInMinutes = timeInMinutes;
            this.numberOfQuestions = numberOfQuestions;
            this.Subject = subject;
            this.questionList = new Qlist($"{subject.Name}.txt"); // to load Q from file
        }

        public virtual void ShowExam()
        {
            // virtual method so i can build my own struct in every exam type
        }
            
        //to check correct answer
       public bool HasWrongAnswer(List<AnswersC> studentAnswers, List<AnswersC> correctAnswers)
        {
            foreach (var ans in studentAnswers)
            {
                bool found = false;
                foreach (var correct in correctAnswers)
                {
                    if (ans.Equals(correct))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {

                    return false;
                }
            }
            return true;
        }
        public List<AnswersC> GetAnswers(int idx, Questions q)
        {
            List<AnswersC> answer = new List<AnswersC>();
            var ans = q.Answers.FirstOrDefault(a => a.Index == idx);
            if (ans != null)
                answer.Add(ans);
            return answer;
        }

        // same but for chooseAll
        public List<AnswersC> GetAnswers(int[] idx, Questions q)
        {
            List<AnswersC> answers = new List<AnswersC>();
            foreach (int i in idx)
            {
                var ans = q.Answers.FirstOrDefault(a => a.Index == i);
                if (ans != null)
                    answers.Add(ans);
            }
            return answers;
        }
    }
}
