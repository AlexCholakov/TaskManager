using DataAccess.Entity;
using DataAccess.Repository;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{

    public partial class frmInfo : Form
    {
        private Info info;
        TasksRepository tr = new TasksRepository("tasks.txt");
        
        public frmInfo(Info info)
        {
            InitializeComponent();
            this.info = info;

            this.tbTimePassed.Text = info.TimePassed.ToString();
            string status = null;
            foreach (Taask task in tr.GetTasks())
            {
                if (info.ParentTaaskId == task.ParentUserId)
                {
                    status = task.Status;
                }
            }
            if (status == "Ongoing")
            {
                rbOngoing.Checked = true;
            }
            else rbFinished.Checked = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tbTimePassed.Text == "")
            {
                MessageBox.Show("Phone can't be empty");
                return;
            }

            this.info.TimePassed = Convert.ToInt32(this.tbTimePassed.Text);
            this.info.UserTime = AuthenticationService.LoggedUser.Username;
            this.info.DateFromTime = DateTime.Now.ToString();
            foreach (Taask task in tr.GetTasks())
            {
                if (task.ParentUserId == info.ParentTaaskId)
                {
                    if (rbOngoing.Checked)
                    {
                        task.Status = "Ongoing";
                    }
                    else task.Status = "Finished";
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
