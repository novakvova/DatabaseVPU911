using Hospital.DAL;
using Hospital.WindowsForm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class MainForm : Form
    {
        bool isAuth = false;
        
        public MainForm()
        {
            LoginForm login_dlg = new LoginForm();
            if (login_dlg.ShowDialog() == DialogResult.OK)
            {
                isAuth = true;
            }
            InitializeComponent();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!isAuth)
            {
                Application.Exit();
            }
            else
            {
                MyContext context = new MyContext();
                foreach (var item in context.Doctors.Include(x => x.Department))
                {
                    object[] row = {
                        $"{item.LastName} {item.FirstName}",
                        $"{item.Stage}",
                        $"{item.Department.Name}"
                    };
                    dataGridView1.Rows.Add(row);
                }
                foreach (var department in context.Departments)
                {
                    CustomComboBoxItem item = new CustomComboBoxItem
                    {
                        Id = department.Id,
                        Name = department.Name
                    };
                    cbDepatments.Items.Add(item);
                }
            }
        }

        private void btnShowProfile_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void profileStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfileForm dlg = new UserProfileForm();
            dlg.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var item = cbDepatments.SelectedItem;
            if(item!=null)
            {
                var dep = cbDepatments.SelectedItem as CustomComboBoxItem;
            }
        }
    }
}
