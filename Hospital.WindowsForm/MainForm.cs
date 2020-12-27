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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //run the program again and close this one
                Process.Start(Application.StartupPath + "\\Hospital.exe");
                //or you can use Application.ExecutablePath

                //close this one
                Process.GetCurrentProcess().Kill();
            }
            catch
            { }
            //MessageBox.Show("Hello");
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
                pbImage.Image = Image.FromFile($"images/{DoctorLogin.Image}");
            }
        }

        private void btnShowProfile_Click(object sender, EventArgs e)
        {
            UserProfileForm dlg = new UserProfileForm();
            dlg.ShowDialog();
        }
    }
}
