using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Taask : BaseEntityWithId
    {
        public int ParentUserId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }
        public string Responsible { get; set; }
        public string Creator { get; set; }
        public string Start { get; set; }
        public string LastEdited { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0} Desc: {1} Grade: {2} Responsible: {3} Creator: {4} Started: {5} Edited: {6} Status: {7}", this.FullName, this.Description, this.Grade, this.Responsible,
                 this.Creator, this.Start, this.LastEdited, this.Status);
        }
        
    }
}
