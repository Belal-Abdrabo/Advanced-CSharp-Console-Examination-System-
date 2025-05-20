using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    public class AnswersC
    {
        int index;
        public string AnswerBody { get; set; }
        public int Index{ set { if (value > 0 && value <= 4) index = value;else Console.WriteLine("Wrong Answer Index");} get { return index;}}

        public AnswersC(int index,string Answer)
        {
                Index = index;
                AnswerBody = Answer;
        }
        public override string ToString()
        {
            return $"Answer-Number= {Index} : {AnswerBody}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is AnswersC ans)
            {
                return ans.Index == Index && ans.AnswerBody.ToLower() == AnswerBody.ToLower() ;
            }
            else return false;
        }
    }
}
