using Hospital.DAL;
using Hospital.WindowsForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class UserProfileForm : Form
    {
        public UserProfileForm()
        {
            InitializeComponent();
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            using (MyContext context = new MyContext())
            {
                var doctor = context.Doctors.SingleOrDefault(x => x.Id == DoctorLogin.Id);
                lblName.Text = $"{doctor.LastName} {doctor.FirstName}";
            }
        }
    }
}
