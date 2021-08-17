﻿using System;

namespace Delegates_Lambdas_Events
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);
    public class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2;
            //del1 += del3;
            del1 += del2 + del3;

            int finalHours = del1(10, WorkType.PrintReports);
            Console.WriteLine(finalHours);
            DoWork(del1);
            Console.ReadLine();
        }

        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 Called " + hours.ToString());
            return hours+1;
        }

        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 Called " + hours.ToString());
            return hours + 2;
        }
        static int WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed3 Called " + hours.ToString());
            return hours + 3;
        }
    }
}
