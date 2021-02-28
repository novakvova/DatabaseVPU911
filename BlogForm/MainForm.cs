using BlogForm.Entities;
using BlogForm.Helpers;
using BlogForm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            loadFromData();
        }
        private void loadFromData()
        {
            ///dgvPosts.Rows.Clear();
            ///var query = _context.Posts
            ///   //.Include(x => x.Category)
            ///   .AsQueryable();
            ///
            ///var list = query.Select(x => new {
            ///    Id = x.Id,
            ///    Title = x.Title,
            ///    Image = x.Image,
            ///    CategoryName = x.Category.Name
            ///})
            ///    .AsQueryable().ToList();
            ///
            ///foreach (var item in list)
            ///{
            ///    string path = Path.Combine(Directory.GetCurrentDirectory(), "images");
            ///    object[] row =
            ///    {
            ///        item.Id,
            ///        ///Тернарний оператор C#, якщо фото немає, то буде null
            ///        ///якщо фото є, то його вантажимо чере Image.FromFile
            ///        item.Image==null, //? null:Image.FromFile(Path.Combine(path, item.Image)),
            ///        item.Title,
            ///        item.CategoryName
            ///    };
            ///    dgvPosts.Rows
            ///        .Add(row);
            ///
            ///}

            #region Begin work Breed

            var categories = _context.Breeds.Select(ic => new BreedGroupVM
            {
                Id = ic.Id,
                Name = ic.Name,
                UrlSlug = ic.UrlSlug,
                ParentId = ic.ParentId
            }).ToList();

            var tree = categories.BuildTree(); //Зробити дерево

            #endregion

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPosts.CurrentRow != null)
            {
                int id = int.Parse(dgvPosts["ColId", dgvPosts.CurrentRow.Index].Value.ToString());
                EditPostForm dlg = new EditPostForm(id);
                if(dlg.ShowDialog()==DialogResult.OK)
                {
                    loadFromData();
                }
            }
        }

        private void btnWorkingTree_Click(object sender, EventArgs e)
        {
            BreedWorkingForm dlg = new BreedWorkingForm(_context);
            dlg.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FilterTestForm dlg = new FilterTestForm(_context);
            dlg.ShowDialog();
        }
    }
}
