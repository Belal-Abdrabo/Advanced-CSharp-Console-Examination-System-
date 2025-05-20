using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Que
{
    internal class Questions
    {

        public string Body {  get; set; }
        
        public int Mark { get; set; }
        
        public Header QHeader { get; set; }
        
        public List<AnswersC> Answers { get; set; } = new List<AnswersC>();
        
        public List<AnswersC> CorrectAnswers { get; set; } =    new List<AnswersC>();
        
        public Questions() { }

        //public Questions(string body,int mark,List<AnswersC> answer , AnswersC CorrectAnswer)
        //{
        //    Body = body;
        //    Mark = mark;
        //    CorrectAnswers.Add(CorrectAnswer);
        //    Answers = answer;
        //}

        public Questions(string body, int mark, List<AnswersC> answer) //chooseone,all
        {
            Body = body;
            Mark = mark;
            Answers = answer;
        } 

        //public Questions(string body, int mark, AnswersC CorrectAnswer)
        //{
        //    Body = body;
        //    Mark = mark;
        //    CorrectAnswers.Add(CorrectAnswer);
        //}
        
        public Questions(string body, int mark) //TQ or FQ
        {
            Body = body;
            Mark = mark;
        }
        
        public override string ToString()
        {
            string correctAns = "";
            string answers = "";
            foreach (AnswersC answer in CorrectAnswers) { correctAns += answer.ToString();}
            foreach (AnswersC answer in Answers) { answers += answer.ToString();}
            return $"{this.QHeader} \n {Body}\t {Mark} \n Answers: {answers}";
        }
        
        internal object getCorrectAnswersIdx()
        {
            int[] idx = new int[CorrectAnswers.Count()];
            for (int i = 0; i < idx.Length; i++)
            {
                idx[i] = CorrectAnswers[i].Index;
            }
            return string.Join(',', idx);
        }

    }
    enum Header
    {
        TrueOrFalse,
        ChooseOne,
        ChooseAll
    }
}
