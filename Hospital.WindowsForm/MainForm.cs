using Hospital.DAL;
using Hospital.WindowsForm.Models;
using Hospital.WindowsForm.Services;
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
        private readonly MyContext _context;
        public MainForm()
        {

            LoginForm login_dlg = new LoginForm();
            if (login_dlg.ShowDialog() == DialogResult.OK)
            {
                isAuth = true;
                _context = new MyContext();
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
                SearchDoctor();


                foreach (var department in _context.Departments)
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
            SearchDoctor search = new SearchDoctor();
            var item = cbDepatments.SelectedItem;
            if(item!=null)
            {
                var dep = cbDepatments.SelectedItem as CustomComboBoxItem;
                search.DepartmentId = dep.Id;
            }
            search.FirstName = txtName.Text;
            SearchDoctor(search);
        }

        private void SearchDoctor(SearchDoctor search = null)
        {
            dataGridView1.Rows.Clear();
            //if (search == null)
            //    search = new SearchDoctor();
            search ??= new SearchDoctor();
            var list = DoctorService.Search(_context, search);
            foreach (var item in list)
            {
                object[] row = {
                        item.Id,
                        item.Name,
                        item.Stage,
                        item.Department
                    };
                dataGridView1.Rows.Add(row);
            }
            lblCount.Text = "Всього записів: "+list.Count().ToString();
        }
    }
}
