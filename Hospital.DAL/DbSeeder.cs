using Hospital.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.DAL
{
    public static class DbSeeder
    {
        public static void SeedAll(MyContext context)
        {
            SeedDepatrment(context);
            SeedDoctor(context);
        }
        private static void SeedDepatrment(MyContext context)
        {
            if(context.Departments.Count()==0)
            {
                context.Departments
                    .Add(
                    new Department
                    {
                        Name="Хіругрія",
                        NumberCabinet=243
                    });

                context.Departments
                    .Add(
                    new Department
                    {
                        Name = "Інфекційне",
                        NumberCabinet = 12
                    });
                context.SaveChanges();
            }
        }

        private static void SeedDoctor(MyContext context)
        {
            if (context.Doctors.Count() == 0)
            {
                context.Doctors
                    .Add(
                    new Doctor
                    {
                        FirstName="Влад",
                        LastName="Яма-Подвал",
                        Login="vladik",
                        Password= PasswordManager.HashPassword("123456"),
                        Stage=15,
                        Department= context.Departments
                        .FirstOrDefault(x=>x.Name== "Хіругрія")
                    });

                context.Doctors
                    .Add(
                    new Doctor
                    {
                        FirstName = "Опенько",
                        LastName = "Лісовик",
                        Login = "beaver",
                        Password = PasswordManager.HashPassword("xvost"),
                        Stage = 25,
                        Department = context.Departments
                        .FirstOrDefault(x => x.Name == "Інфекційне")
                    });


                context.SaveChanges();
            }
        }
    }
}
