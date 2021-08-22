using System;

namespace Delegates_Lambdas_Events
{
    public delegate int BizRuleDelegate(int x, int y);

    public class Program
    {
        static void Main(string[] args)
        {
            BizRuleDelegate addDel = (x, y) => x + y;
            BizRuleDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(3, 4, addDel);
            data.Process(3, 4, multiplyDel);

            var worker = new Worker();
            // Anonymous method example
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Inside the anonymous method + hours: " +  e.Hours.ToString());
            }; // End of anonymous method but remember in general lamdas are more popular for inline solutions

            worker.WorkPerformed += Worker_workPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.WorkPerformed += (s, e) => Console.WriteLine("Lambda hours worked : " + e.Hours + " " + e.WorkType);
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Lambda with brackets ..Hours worked : " + e.Hours + " " + e.WorkType);
            };
            worker.DoWork(8, WorkType.PrintReports);
        }

        private static void Worker_workPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked : " + e.Hours + " " + e.WorkType);
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work is completed");
        }

    }
}
