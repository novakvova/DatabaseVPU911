using BlogForm.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlogForm
{
    public partial class EditPostForm : Form
    {
        private readonly int _id;
        private readonly EFContext _context;
        public EditPostForm(int id)
        {
            InitializeComponent();
            _id = id;
            _context = new EFContext();
            initDataEdit();
        }
        private void initDataEdit()
        {
            var post = _context.Posts
                .SingleOrDefault(p => p.Id == _id);
            foreach(var item in _context.Categories)
            {
                cbCategory.Items.Add(item);
                if (item.Id == post.CategoryId)
                    cbCategory.SelectedItem = item;
            }
            txtTitle.Text = post.Title;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var post = _context.Posts
                .SingleOrDefault(p => p.Id == _id);
            post.CategoryId = (cbCategory.SelectedItem as Category).Id;
            post.Title = txtTitle.Text;
            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
        }
    }
}
