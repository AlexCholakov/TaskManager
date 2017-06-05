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
    public partial class frmMain : Form
    {
        UsersRepository ur = new UsersRepository("users.txt");
        public frmMain()
        {

            InitializeComponent();
            if (ur.GetById(AuthenticationService.LoggedUser.Id).IsAdmin == "no")
            {
                administrationToolStripMenuItem.Enabled = false;
            }

        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTasks frmManageTasks = new frmManageTasks();
            frmManageTasks.MdiParent = this;
            frmManageTasks.Show();
        }

        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
