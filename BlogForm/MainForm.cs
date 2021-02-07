using BlogForm.Entities;
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

namespace BlogForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            EFContext context = new EFContext();
            Seeder.SeedDatabase(context);
            var query = context.Posts.Include(x => x.Category).AsQueryable();

            //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //var sql = query.ToString();
            var list = query.ToList();
        }

    }
}
