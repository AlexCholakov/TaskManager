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
    public partial class frmEditTask : Form
    {
        private Taask task;
        UsersRepository ur = new UsersRepository("users.txt");
        List<User> users = new List<User>();
        public frmEditTask(Taask task)
        {
            InitializeComponent();
            
            this.task = task;

            this.tbFullName.Text = task.FullName;
            this.tbDescription.Text = task.Description;
            this.tbGrade.Text = task.Grade.ToString();
            /*if (task.Status == null)
            {
                rbOngoing.Checked = true;
            }
            else rbFinished.Checked = true;
            */
            users = ur.GetAll();
            foreach (User user in users)
            {
                this.cbUsers.Items.Add(user.Username);
            }
            this.cbUsers.SelectedItem = task.Responsible;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbFullName.Text == "")
            {
                MessageBox.Show("Full name can't be empty");
                return;
            }

            if (tbDescription.Text == "")
            {
                MessageBox.Show("Description can't be empty");
                return;
            }
            if (tbGrade.Text == "")
            {
                MessageBox.Show("Grade can't be empty");
                return;
            }

            task.FullName = this.tbFullName.Text;
            task.Description = this.tbDescription.Text;
            task.Grade = Convert.ToInt32(this.tbGrade.Text);

            users = ur.GetAll();
            foreach (User user in users)
            {
                if (user.Username == cbUsers.SelectedItem.ToString())
                {
                    task.Responsible = user.Username;
                }
            }

            task.Creator = AuthenticationService.LoggedUser.Username;
            if (task.Start == null)
            {
                task.Start = DateTime.Now.ToString();
            }
            task.LastEdited = DateTime.Now.ToString();
            if (task.Status == null)
            {
                task.Status = "Ongoing";
            }
            /*if (rbFinished.Checked)
            {
                task.Status = "Complete.";
            }
            else task.Status = "Ongoing.";*/
            this.DialogResult = DialogResult.OK;
        }
    }
}
