using System;

namespace Delegates_Lambdas_Events
{

    public class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            // Anonymous method example
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Inside the anonymous method + hours: " +  e.Hours.ToString());
            }; // End of anonymous method but remember in general lamdas are more popular for inline solutions

            worker.WorkPerformed += Worker_workPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(8, WorkType.PrintReports);
            Console.Read();
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
