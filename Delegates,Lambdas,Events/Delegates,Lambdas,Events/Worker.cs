using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Lambdas_Events
{
    public class Worker
    {
        public event WorkPerformedHandler workPerformed;
        public event EventHandler WorkCompleted;

        public virtual void DoWork(int hours, WorkType worktype)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, worktype);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType worktype)
        {
            //if (workPerformed != null)
            //{
            //    workPerformed(hours, worktype);
            //}

            WorkPerformedHandler del = workPerformed as WorkPerformedHandler;
            if(del != null)//Listeners are attached
            {
                del(hours, worktype);
            }
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)//Listeners are attached
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
