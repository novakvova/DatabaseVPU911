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
        //номер сторінки
        private int _page = 1;
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

                cbCountShowOnePage.Items.AddRange(
                    new List<CustomComboBoxItem> {
                            new CustomComboBoxItem { Id=1, Name="10" },
                            new CustomComboBoxItem { Id=2, Name="20" },
                            new CustomComboBoxItem { Id=3, Name="30" },
                            new CustomComboBoxItem { Id=4, Name="50" }
                       }.ToArray()
                    );
                cbCountShowOnePage.SelectedIndex = 0;
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
            //Якщо робимо пошук переходимо на початок
            _page = 1;
            SearchDoctor(GetSearchInputValue());
        }

        private SearchDoctor GetSearchInputValue()
        {
            SearchDoctor search = new SearchDoctor();
            var item = cbDepatments.SelectedItem;
            if (item != null)
            {
                var dep = cbDepatments.SelectedItem as CustomComboBoxItem;
                search.DepartmentId = dep.Id;
            }
            search.FirstName = txtName.Text;
            var countSelect = cbCountShowOnePage.SelectedItem as CustomComboBoxItem;
            search.CountShowOnePage = int.Parse(countSelect.Name);
            return search;
        }

        private void SearchDoctor(SearchDoctor search = null)
        {
            dataGridView1.Rows.Clear();
            //if (search == null) 
            //    search = new SearchDoctor();
            search ??= new SearchDoctor();
            search.Page = _page;
            var result = DoctorService.Search(_context, search);
            foreach (var item in result.Doctors)
            {
                object[] row = {
                        item.Id,
                        item.Name,
                        item.Stage,
                        item.Department
                    };
                dataGridView1.Rows.Add(row);
            }
            int begin = (_page - 1) * search.CountShowOnePage + 1;
            int end = begin + (search.CountShowOnePage - 1);
            lblRange.Text = $"Показ: {begin} - {end}";
            lblCount.Text = "Всього записів: "+ result.CountRows.ToString();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (_page > 1)
            {
                _page -= 1;
                SearchDoctor(GetSearchInputValue());
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _page += 1;
            SearchDoctor(GetSearchInputValue());
        }


    }
}
