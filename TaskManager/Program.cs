using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin loginForm = new frmLogin();
            DialogResult loginResult = loginForm.ShowDialog();

            if (loginResult == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }
        }
    }
}
