using BlogForm.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace BlogForm
{
    public partial class AddValueForm : Form
    {
        private readonly EFContext _context;
        public AddValueForm(EFContext context)
        {
            _context = context;
            InitializeComponent();
            LoadForm();
        }

        public void LoadForm()
        {
            // Отримуємо назви фільтрів в комбобокс
            var queryName = from f in _context.FilterNames.AsQueryable() select f.Name;
            foreach (var item in queryName)
            {
                cbFilter.Items.Add(item);
            }
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            _context.FilterValues.Add(
                new FilterValue
                {
                    Name = tbValue.Text
                });
            _context.SaveChanges();
            var nameId = _context.FilterNames
                .SingleOrDefault(fn => fn.Name == cbFilter.SelectedItem.ToString()).Id;
            var valueId = _context.FilterValues
                .SingleOrDefault(fv => fv.Name == tbValue.Text).Id;
            // Зв'язуємо в групу назву фільтра і додане значення
            if (_context.FilterNameGroups
                .SingleOrDefault(fng => fng.FilterValueId == valueId
                && fng.FilterNameId == nameId) == null)
            {
                _context.FilterNameGroups.Add(
                    new FilterNameGroup
                    {
                        FilterNameId = nameId,
                        FilterValueId = valueId
                    });
                _context.SaveChanges();
            }
            this.Close();
        }
    }
}
