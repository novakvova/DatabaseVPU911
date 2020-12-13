﻿using Hospital.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void Form1_Load(object sender, EventArgs e)
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
        }
    }
}
