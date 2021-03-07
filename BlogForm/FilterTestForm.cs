using BlogForm.Entities;
using BlogForm.Models;
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
    public partial class FilterTestForm : Form
    {
        private readonly EFContext _context;
        public IQueryable<FilterName> filter { get; set; }

        /// <summary>
        /// Точка відліку для першого графічного елемента (відступ по осі Х)
        /// </summary>
        const int startX = 15;

        /// <summary>
        /// Точка відліку для першого графічного елемента (відступ по осі У)
        /// </summary>
        const int startY = 15;

        /// <summary>
        /// Інтервал між графічними елементами в пікселях
        /// </summary>
        const int interval = 8;

        /// <summary>
        /// Висота одного чекбокса
        /// </summary>
        const int checkBoxHeight = 15;

        /// <summary>
        /// Зміщення по осі У для першого фільтра
        /// </summary>
        public int dy1 { get; set; }

        /// <summary>
        /// Зміщення по осі У для другого фільтра
        /// </summary>
        public int dy2 { get; set; }

        /// <summary>
        /// Кількість дітей першого фільтра
        /// </summary>
        public int CountOfBrands { get; set; }

        /// <summary>
        /// Кількість дітей першого фільтра
        /// </summary>
        public int CountOfPowers { get; set; }

        public FilterTestForm(EFContext context)
        {
            InitializeComponent();
            _context = context;
            Seeder.SeedDatabase(_context);
            LoadForm();
        }
        private void LoadForm()
        {
            GetListFilters();

            // Виводимо кнопки для фільтра брендів і для його очищення
            btnFilterBrand.Location = new Point(startX, startY);
            btnClosedBrand.Location = new Point(startX + btnFilterBrand.Width + interval, startY);

            // Виводимо панель фільтрів по бренду
            pnlFilterBrand.Location = new Point(startX, startY + btnFilterBrand.Height + interval / 2);
            pnlFilterBrand.Height = 0;

            // Виводимо кнопки для фільтра по потужності і для його очищення
            btnFilterPower.Location = new Point(startX, startY + btnFilterBrand.Height + interval);
            btnClosedPower.Location = new Point(startX + btnFilterPower.Width + interval,
                startY + btnClosedBrand.Height + interval);

            // Виводимо панель фільтрів по потужності
            pnlFilterPower.Location = new Point(startX, startY + btnFilterBrand.Height
                + interval + btnFilterPower.Height + interval / 2);
            pnlFilterPower.Height = 0;


        }
        /// <summary>
        /// Зсунення вниз кнопки Потужність
        /// </summary>
        /// <param name="move"></param>
        private void MoveFilterPower(bool move)
        {
            // Якщо передаємо в параметрі тру, то зсовуємо кнопку вниз
            if (move)
            {
                btnFilterPower.Location = new Point(startX, startY + btnFilterBrand.Height + interval + pnlFilterBrand.Height);
                btnClosedPower.Location = new Point(startX + btnFilterPower.Width + interval, startY + btnClosedBrand.Height + interval + pnlFilterBrand.Height);
                pnlFilterPower.Location = new Point(startX, startY + btnFilterBrand.Height + interval + pnlFilterBrand.Height + btnFilterPower.Height + interval / 2);
                pnlFilterPower.Height = 0;
            }
            // інакше лишаємо її на місці
            else
            {
                btnFilterPower.Location = new Point(startX, startY + btnFilterBrand.Height + interval);
                btnClosedPower.Location = new Point(startX + btnFilterPower.Width + interval, startY + btnClosedBrand.Height + interval);
                pnlFilterPower.Location = new Point(startX, startY + btnFilterBrand.Height + interval + btnFilterPower.Height + interval / 2);
                pnlFilterPower.Height = 0;
            }

        }
        private void btnFilterBrand_Click(object sender, EventArgs e)
        {
            // Очищаємо панель чекбоксів
            pnlFilterBrand.Controls.Clear();
            // Перший чекбокс буде виводитись з нульової позиції
            dy1 = 0;
            // Отримуємо з БД список значень по даному фільтру
            List<string> checksBrand = new List<string>();
            var filters = GetListFilters();
            var result = from x in filters
                         where x.Name == btnFilterBrand.Text
                         select x.Children;
            foreach (var item in result)
            {
                foreach (var it in item)
                {
                    checksBrand.Add(it.Value);
                }
            }
            // Отримуємо кількість значень по фільтру
            CountOfBrands = checksBrand.Count();
            // Задаємо висоту панелі виведення чекбоксів
            pnlFilterBrand.Height = 2 * checkBoxHeight * (CountOfBrands - 1)
                + interval + btnSaveChoiceBrand.Height;
            // Виводимо чекбокси
            foreach (var item in checksBrand)
            {
                CheckBox chb = new CheckBox();
                chb.AutoSize = true;
                chb.Location = new System.Drawing.Point(1, dy1);
                chb.Size = new System.Drawing.Size(82, checkBoxHeight);
                chb.Text = item.ToString();
                chb.UseVisualStyleBackColor = true;
                pnlFilterBrand.Controls.Add(chb);
                // Зміщуємо виведення наступного чекбокса на його висоту + інтервал
                dy1 = dy1 + checkBoxHeight + interval;
            }
            // Відображуємо кнопку Застосувати фільтр 
            btnSaveChoiceBrand.Visible = true;
            btnSaveChoiceBrand.Location = new Point(0, 2 * checkBoxHeight * (CountOfBrands - 1));
            pnlFilterBrand.Controls.Add(btnSaveChoiceBrand);
            // Зсовуємо наступну кнопку вниз
            MoveFilterPower(true);
        }
        private void btnClosedBrand_Click(object sender, EventArgs e)
        {
            // Очищуємо панель з чекбоксами
            pnlFilterBrand.Controls.Clear();
            // Ховаємо панель чекбоксів
            pnlFilterBrand.Height = 0;
            // Підтягуємо наступну кнопку назад
            MoveFilterPower(false);
        }
        private void btnFilterPower_Click(object sender, EventArgs e)
        {
            // Очищаємо панель чекбоксів
            pnlFilterPower.Controls.Clear();
            // Перший чекбокс буде виводитись з нульової позиції
            dy2 = 0;
            // Отримуємо з БД список значень по даному фільтру
            List<string> checksPower = new List<string>();
            var filters = GetListFilters();
            var result = from x in filters
                         where x.Name == btnFilterPower.Text
                         select x.Children;
            foreach (var items in result)
            {
                foreach (var it in items)
                {
                    checksPower.Add(it.Value);
                }
            }
            // Отримуємо кількість значень по фільтру
            CountOfPowers = checksPower.Count();
            // Задаємо висоту панелі виведення чекбоксів
            pnlFilterPower.Height = 2 * checkBoxHeight * (CountOfPowers - 1)
                + interval + btnSaveChoicePower.Height;
            // Виводимо чекбокси
            foreach (var item in checksPower)
            {
                CheckBox chb = new CheckBox();
                chb.AutoSize = true;
                chb.Location = new System.Drawing.Point(1, dy2);
                chb.Size = new System.Drawing.Size(82, checkBoxHeight);
                chb.Text = item.ToString();
                chb.UseVisualStyleBackColor = true;
                pnlFilterPower.Controls.Add(chb);
                // Зміщуємо виведення наступного чекбокса на його висоту + інтервал
                dy2 = dy2 + checkBoxHeight + interval;
            }
            // Відображуємо кнопку Застосувати фільтр 
            btnSaveChoicePower.Visible = true;
            btnSaveChoicePower.Location = new Point(0, 2 * checkBoxHeight * (CountOfPowers - 1));
            pnlFilterPower.Controls.Add(btnSaveChoicePower);
        }
        private void btnClosedPower_Click(object sender, EventArgs e)
        {
            // Очищуємо панель з чекбоксами
            pnlFilterPower.Controls.Clear();
            // Ховаємо панель чекбоксів
            pnlFilterPower.Height = 0;
        }
        private List<FNameViewModel> GetListFilters()
        {
            var queryName = from f in _context.FilterNames.AsQueryable()
                            select f;
            var queryGroup = from g in _context.FilterNameGroups.AsQueryable()
                             select g;
            //Отримуємо загальну множину значень
            var query = from u in queryName
                        join g in queryGroup on u.Id equals g.FilterNameId into ua
                        from aEmp in ua.DefaultIfEmpty()
                        select new
                        {
                            FNameId = u.Id,
                            FName = u.Name,
                            FValueId = aEmp != null ? aEmp.FilterValueId : 0,
                            FValue = aEmp != null ? aEmp.FilterValueOf.Name : null,
                        };

            //Групуємо по іменам і сортуємо по спаданню імен
            var groupNames = query.AsEnumerable()
                      .GroupBy(f => new { Id = f.FNameId, Name = f.FName })
                      .Select(g => g)
                      .OrderByDescending(p => p.Key.Name);

            //По групах отримуємо
            var result = from fName in groupNames
                         select
                         new FNameViewModel
                         {
                             Id = fName.Key.Id,
                             Name = fName.Key.Name,
                             Children = fName.Select(x =>
                                   new FValueViewModel
                                   {
                                       Id = x.FValueId,
                                       Value = x.FValue
                                   }).OrderBy(l => l.Value).ToList()
                         };

            return result.ToList();
        }
        /// <summary>
        /// Додавання значення в фільтр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFilterValue_Click(object sender, EventArgs e)
        {
            new AddValueForm(_context).ShowDialog();
        }



        //private readonly EFContext _context;
        //public FilterTestForm(EFContext context)
        //{
        //    InitializeComponent();
        //    _context = context;
        //    var filters = GetListFilters();
        //}

        //private List<FNameViewModel> GetListFilters()
        //{
        //    var queryName = from f in _context.FilterNames.AsQueryable()
        //                    select f;
        //    var queryGroup = from g in _context.FilterNameGroups.AsQueryable()
        //                     select g;
        //    //Отримуємо загальну множину значень
        //    var query = from u in queryName
        //                join g in queryGroup on u.Id equals g.FilterNameId into ua
        //                from aEmp in ua.DefaultIfEmpty()
        //                select new
        //                {
        //                    FNameId = u.Id,
        //                    FName = u.Name,
        //                    FValueId = aEmp != null ? aEmp.FilterValueId : 0,
        //                    FValue = aEmp != null ? aEmp.FilterValueOf.Name : null,
        //                };


        //    //Групуємо по іменам і сортуємо по спаданню імен

        //    var groupNames = query.AsEnumerable()
        //              .GroupBy(f => new { Id = f.FNameId, Name = f.FName })
        //              .Select(g => g)
        //              .OrderByDescending(p => p.Key.Name);

        //    //По групах отримуємо
        //    var result = from fName in groupNames
        //                 select
        //                 new FNameViewModel
        //                 {
        //                     Id = fName.Key.Id,
        //                     Name = fName.Key.Name,
        //                     Children =  fName.Select(x=>
        //                            new FValueViewModel {
        //                                Id=x.FValueId,
        //                                Value=x.FValue
        //                     }).OrderBy(l=>l.Value).ToList()

        //                 };

        //    return result.ToList();

        //}


    }
}
