using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Que
{
    class ChooseAll:Questions
    {
        public ChooseAll(string body, int mark, List<AnswersC> Answers, int[] CorrectAnswerIndex) : base(body: body, mark: mark, answer: Answers)
        {
            QHeader = Header.ChooseAll;

            foreach (var answer in Answers)
            {
                for(int i = 0; i< CorrectAnswerIndex.Length;i++)
                {
                    if(answer.Index == CorrectAnswerIndex[i])
                    {
                        base.CorrectAnswers.Add(answer);
                        break; //to back into foreach to check another answer
                    }
                }
                
            }
        }
    }
}
