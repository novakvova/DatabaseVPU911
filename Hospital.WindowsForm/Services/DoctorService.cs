using Hospital.DAL;
using Hospital.WindowsForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.WindowsForm.Services
{
    public class DoctorService
    {
        public static List<DoctorItemView> Search(MyContext context, SearchDoctor search)
        {
            //отримуємо усі записи в оперативку
            //var query = context.Doctors.AsEnumerable();//.AsQueryable();
            //ми формуємо sql запит до БД - нічого з БД не отримуємо в цьому рядку
            var query = context.Doctors.AsQueryable();
            //Якщо DepartmentId !=null
            if (search.DepartmentId.HasValue)
            {
                query = query.Where(x => x.DepartmentId == search.DepartmentId.Value);
            }
            //Якщо у search.Name != null
            if (!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(search.FirstName));
            }

            var list = query
                .Select(x=>new DoctorItemView {
                    Id=x.Id,
                    Name = x.LastName+" "+x.FirstName,
                    Stage=x.Stage,
                    Department=x.Department.Name
                }).ToList();
            return list;
        }
    }
}
