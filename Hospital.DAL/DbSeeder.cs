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
            SeedQuestion(context);
        }


        private static void SeedQuestion(MyContext context)
        {
            if (context.Questions.Count()==0)
            {
                var question = new Question
                {
                    Text = "Улюблена марка автомобіля Блонського?",
                };

                context.Questions.Add(question);
                context.SaveChanges();
                var answers = new List<Answer>
                {
                    new Answer {Text="Жигуль",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Москвіч",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="ЗАЗ",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Тесла",IsTrue=true,QuestionId=question.Id}

                };
                context.Answers.AddRange(answers);
                context.SaveChanges();
                question = new Question
                {
                    Text = "Яка модель телефона у Блонського?",
                };

                context.Questions.Add(question);
                context.SaveChanges();
                 answers = new List<Answer>
                {
                    new Answer {Text="Нокіа",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Еріксон",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Самсунг",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Айфон",IsTrue=true,QuestionId=question.Id}

                };
                context.Answers.AddRange(answers);
                context.SaveChanges();


            }

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
                        Image="1.jpg",
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
                        Image="3.jpg",
                        Stage = 25,
                        Department = context.Departments
                        .FirstOrDefault(x => x.Name == "Інфекційне")
                    });


                context.SaveChanges();
            }
        }
    }
}
