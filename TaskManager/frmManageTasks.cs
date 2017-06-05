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
    public partial class frmManageTasks : Form
    {
        private void RefreshItems()
        {
            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            this.lbItems.Items.Clear();
            /*foreach (Taask task in tasksRepository.GetAll(AuthenticationService.LoggedUser.Id))
            {
                this.lbItems.Items.Add(task);
            }*/

            foreach (Taask task in tasksRepository.GetTasks())
            {
                if (task.Creator == AuthenticationService.LoggedUser.Username || task.Responsible == AuthenticationService.LoggedUser.Username)
                {
                    this.lbItems.Items.Add(task);
                }
            }

            if (this.lbItems.Items.Count > 0)
                this.lbItems.SelectedIndex = 0;
        }
        private void RefreshSubitems()
        {
            InfoRepository infoRepository = new InfoRepository("info.txt");
            listBox1.Items.Clear();

            Taask task = (Taask)lbItems.SelectedItem;
            foreach (Info info in infoRepository.GetAll(task.Id))
            {
                listBox1.Items.Add(info);
            }
        }


        public frmManageTasks()
        {
            InitializeComponent();

            RefreshItems();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Taask task = new Taask();
            task.ParentUserId = AuthenticationService.LoggedUser.Id;

            frmEditTask frmEditTask = new frmEditTask(task);
            if (frmEditTask.ShowDialog() == DialogResult.OK)
            {
                TasksRepository tasksRepository = new TasksRepository("tasks.txt");
                tasksRepository.Save(task);

                RefreshItems();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.lbItems.SelectedItem == null)
                return;

            Taask task = (Taask)this.lbItems.SelectedItem;

            frmEditTask frmEditTask = new frmEditTask(task);
            if (frmEditTask.ShowDialog() == DialogResult.OK)
            {
                TasksRepository tasksRepository = new TasksRepository("tasks.txt");
                tasksRepository.Save(task);

                RefreshItems();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.lbItems.SelectedItem == null)
                return;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this item", "Delete item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            Taask task = (Taask)this.lbItems.SelectedItem;

            TasksRepository tasksRepository = new TasksRepository("tasks.txt");
            tasksRepository.Delete(task);

            RefreshItems();
        }

        private void frmManageTasks_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedItem == null)
                return;

            Taask task = (Taask)lbItems.SelectedItem;
            Info info = new Info();
            info.ParentTaaskId = task.Id;

            frmInfo frmInfo = new frmInfo(info);
            if (frmInfo.ShowDialog() == DialogResult.OK)
            {
                InfoRepository infoRepository = new InfoRepository("info.txt");
                infoRepository.Save(info);

                RefreshSubitems();
                RefreshItems();
            }
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSubitems();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
