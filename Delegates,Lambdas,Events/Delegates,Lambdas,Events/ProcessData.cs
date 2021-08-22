using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Lambdas_Events
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRuleDelegate del)
        {
            var result = del(x,y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int,int> action)
        {
            action(x,y);
            Console.WriteLine("Action has been processed");
        }
    }
}
