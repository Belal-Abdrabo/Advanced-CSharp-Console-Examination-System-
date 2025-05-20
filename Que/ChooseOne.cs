
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Que
{
    class ChooseOne:Questions
    {
        public ChooseOne(string body, int mark,List<AnswersC> Answers, int CorrectAnswerIndex) : base(body: body, mark: mark,answer:Answers)
        {
            QHeader = Header.ChooseOne;

            foreach (var answer in Answers)
            {
                if (answer.Index == CorrectAnswerIndex)
                {
                    base.CorrectAnswers.Add(answer);
                    break;
                }
            }
        }
    }
}
