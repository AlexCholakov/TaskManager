using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Info  : BaseEntityWithId
    {
        public int ParentTaaskId { get; set; }
        public string UserTime { get; set; }
        public int TimePassed { get; set; }
        public string DateFromTime { get; set; }
        public string[] Comments { get; set; }

        public override string ToString()
        {
            return String.Format("User: {0}, Time: {1}, Date: {2}, Status: {3}", this.UserTime, this.TimePassed, this.DateFromTime, GetStatus());
        }

        private string GetStatus()
        {
            string status = null;
            TasksRepository tr = new TasksRepository("tasks.txt");
            foreach (Taask task in tr.GetTasks())
            {
                if (ParentTaaskId == task.ParentUserId)
                {
                    status = task.Status;
                }
            }
            return status;
        }
    }
}
