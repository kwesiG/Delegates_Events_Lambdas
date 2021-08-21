using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates_Lambdas_Events
{
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public virtual void DoWork(int hours, WorkType worktype)
        {
            for (int i = 0; i < hours; i++)
            {
                Thread.Sleep(1000);
                OnWorkPerformed(i + 1, worktype);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType worktype)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)//Check if there are listeners are attached
            {
                del(this, new WorkPerformedEventArgs(hours, worktype));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)//Check if there are listeners are attached
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
