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
        private readonly EFContext _context;
        public MainForm()
        {
            InitializeComponent();
            _context = new EFContext();
            Seeder.SeedDatabase(_context);
            var query = _context.Posts
                //.Include(x => x.Category)
                .AsQueryable();

            //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //var sql = query.ToString();
            var list = query.Select(x=>new {
             Id= x.Id,
             Title=x.Title,
             CategoryName= x.Category.Name
            })
                .AsQueryable().ToList();

            //DataGridViewComboBoxCell comboBox = new DataGridViewComboBoxCell();
            
            //comboBox.Items.Add("Сало");
            //comboBox.Items.Add("Цибуля");

            int i = 0;
            foreach (var item in list)
            {
                
                object[] row =
                {
                    item.Id,
                    item.Title,
                    //"Славік"
                    //comboBox
                    //item.CategoryName
                    //l_objGridDropbox
                };
                dgvPosts.Rows
                    .Add(row);
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                dgvPosts[2, i] = l_objGridDropbox;
                l_objGridDropbox.DataSource = GetPaidWithTable();
                l_objGridDropbox.ValueMember = "Id";
                l_objGridDropbox.DisplayMember = "Name";
                i++;
            }
            this.dgvPosts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosts_CellValueChanged);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //dgvPosts
            MessageBox.Show("Редагувати");
        }

        private void dgvPosts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            try
            {
                int id = int.Parse(dgvPosts["ColId", dgvPosts.CurrentRow.Index].Value.ToString());
                string title = dgvPosts["ColText", dgvPosts.CurrentRow.Index].Value.ToString();
                
                //MessageBox.Show($"Hello {id} {title}");
                var post = _context.Posts.SingleOrDefault(p => p.Id == id);
                post.Title = title;
                _context.SaveChanges();

            } catch(Exception ex)
            {
                
            }
        }

        private void dgvPosts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();

                // Check the column  cell, in which it click.  
                //if (dgvPosts.Columns[e.ColumnIndex].Name.Contains("Description"))
                //{
                //    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                //    dgvPosts[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                //    l_objGridDropbox.DataSource = GetDescriptionTable(); // Bind combobox with datasource.  
                //    l_objGridDropbox.ValueMember = "Description";
                //    l_objGridDropbox.DisplayMember = "Description";

                //}
                //MessageBox.Show(dgvPosts.Columns[e.ColumnIndex].Name);
                if (dgvPosts.Columns[e.ColumnIndex].Name.Contains("ColCategory"))
                {
                    dgvPosts[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = GetPaidWithTable();
                    l_objGridDropbox.ValueMember = "Id";
                    l_objGridDropbox.DisplayMember = "Name";
                }



            }
        }

        /// <summary>  
        /// Get datatable of PaidWIth.  
        /// </summary>  
        /// <returns></returns>  
        private DataTable GetPaidWithTable()
        {
            DataTable l_dtPaidwith = new DataTable();
            l_dtPaidwith.Columns.Add("Name", typeof(string));
            l_dtPaidwith.Columns.Add("Id", typeof(string));

            foreach(var item in _context.Categories.ToList())
            {
                l_dtPaidwith.Rows.Add(item.Name, item.Id.ToString());
                //l_dtPaidwith.Rows.Add("DebitCard", "DC");
            }

            return l_dtPaidwith;
        }

        // <summary>  
        /// Get datatable of description.  
        /// </summary>  
        /// <returns></returns>  
        private DataTable GetDescriptionTable()
        {
            DataTable l_dtDescription = new DataTable();
            l_dtDescription.Columns.Add("Description", typeof(string));
            l_dtDescription.Columns.Add("Type", typeof(string));

            l_dtDescription.Rows.Add("Lunch", "Expense");
            l_dtDescription.Rows.Add("Dinner", "Expense");
            l_dtDescription.Rows.Add("Breakfast", "Expense");
            l_dtDescription.Rows.Add("Designing", "Service");
            l_dtDescription.Rows.Add("Drawing", "Service");
            l_dtDescription.Rows.Add("Paper", "Material");
            l_dtDescription.Rows.Add("DrawingBoard", "Material");

            return l_dtDescription;
        }
    }
}
