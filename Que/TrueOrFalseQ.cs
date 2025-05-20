using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Que
{
    class TrueOrFalseQ:Questions
    {



        public TrueOrFalseQ(string body, int mark, int CorrectAnswerIndex) : base(body: body, mark:mark)
        {
            QHeader = Header.TrueOrFalse;
            base.Answers.Add(new AnswersC(1, "true"));
            base.Answers.Add(new AnswersC(2, "false"));
            if (CorrectAnswerIndex == 1) base.CorrectAnswers.Add(new AnswersC(1, "true"));
            else if (CorrectAnswerIndex == 2) base.CorrectAnswers.Add(new AnswersC(2, "false"));
            else throw new Exception("Wrong Correct Answer");
        }







    }
}
