using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogForm.Entities
{
    public static class Seeder
    {
        public static void SeedDatabase(EFContext context)
        {
            SeedCategory(context);
            SeedTag(context);
            SeedPost(context);
            SeedTagPost(context);
            SeedBreed(context);

            SeedFilter(context);
        }
        private static void SeedCategory(EFContext context)
        {
            if(context.Categories.Count()==0)
            {
                context.Categories
                    .Add(new Category { Name = "Програмування" });
                context.Categories
                    .Add(new Category { Name = "Жилізо" });
                context.Categories
                    .Add(new Category { Name = "Дизайн" });
                context.SaveChanges();
            }
        }

        private static void SeedTag(EFContext context)
        {
            if (context.Tags.Count() == 0)
            {
                context.Tags
                    .Add(new Tag { Name = "С#" });
                context.Tags
                    .Add(new Tag { Name = "Процесор" });
                context.Tags
                    .Add(new Tag { Name = "Мамка" });
                context.Tags
                    .Add(new Tag { Name = "Java" });
                context.SaveChanges();
            }
        }

        private static void SeedPost(EFContext context)
        {
            if (context.Posts.Count() == 0)
            {
                context.Posts
                    .Add(new Post { 
                        Title = "Search for news using C#",
                        Text = "Use this quickstart to make your first call to the Bing News Search API. " +
                        "This simple C# application sends a news search query to the API, and displays the JSON response.",
                        CategoryId=1
                    });
                context.Posts
                    .Add(new Post { 
                        Title = "Java 8 Features",
                        Text = "Let’s have a brief look on these Java 8 features. " +
                        "I will provide some code snippets for better understanding, so if you want to run programs in Java 8, " +
                        "you will have to setup Java 8 environment by following steps.",
                        CategoryId=null
                    });
                context.Posts
                    .Add(new Post { 
                        Title = "Что нового в C# 9.0",
                        Text = "Среди них — новый метод доступа к свойству — init, " +
                        "не позволяющий изменять свойства после инициализации, " +
                        "with-выражения для изменения свойств объекта прямо " +
                        "здесь и сейчас, записи и новые возможности сопоставления шаблонов.",
                        CategoryId=1
                    });
                context.SaveChanges();
            }
        }

        private static void SeedTagPost(EFContext context)
        {
            if (context.TagPosts.Count() == 0)
            {
                context.TagPosts
                    .Add(new TagPost
                    {
                        PostId=1,
                        TagId=1,
                    });
                context.TagPosts
                    .Add(new TagPost
                    {
                        PostId = 1,
                        TagId = 4,
                    });
                context.TagPosts
                    .Add(new TagPost
                    {
                        PostId = 2,
                        TagId = 4,
                    });
                context.TagPosts
                    .Add(new TagPost
                    {
                        PostId = 3,
                        TagId = 1,
                    });
                context.TagPosts
                    .Add(new TagPost
                    {
                        PostId = 3,
                        TagId = 2,
                    });
                context.TagPosts
                    .Add(new TagPost
                    {
                        PostId = 3,
                        TagId = 3,
                    });
                context.SaveChanges();
            }
        }

        #region Сідимо категорії
        private static void SeedBreed(EFContext context)
        {
            if (context.Breeds.Count() == 0)
            {
                string urlSlug = "computers-notebooks";
                AddParent(context, urlSlug, "Ноутбуки та комп’ютери");
                AddChildToParent(context, urlSlug, "notebooks", "Ноутбуки");
                AddChildToParent(context, urlSlug, "computers", "Комп'ютери, неттопи, моноблоки");
                AddChildToParent(context, urlSlug, "monitors", "Монітори");

                urlSlug = "notebooks";
                AddChildToParent(context, urlSlug, "gamming", "Ігрові");
                AddChildToParent(context, urlSlug, "office", "Офісні");

                urlSlug = "telefony-tv-i-ehlektronika";
                AddParent(context, urlSlug, "Смартфони, ТВ і електроніка");
                AddChildToParent(context, urlSlug, "phones-mp3-gps", "Телефони, навушники, GPS");
                AddChildToParent(context, urlSlug, "tv-photo-video", "ТВ, Аудіо/Відео, Фото");
            }
        }
        private static void AddParent(EFContext context, string urlSlug, string name)
        {
            context.Breeds.Add(new Breed
            {
                Name = name,
                ParentId = null,
                UrlSlug = urlSlug
            });
            context.SaveChanges();
        }

        private static void AddChildToParent(EFContext context, string parentSlug, string urlSlug, string name)
        {
            var parent = context.Breeds.SingleOrDefault(x => x.UrlSlug == parentSlug);
            context.Breeds.Add(new Breed
            {
                Name = name,
                ParentId = parent.Id,
                UrlSlug = urlSlug
            });
            context.SaveChanges();
        }



        #endregion

        #region Фільтри
        private static void SeedFilter(EFContext context)
        {
            #region tblFilterNames - Назви фільтрів
            string[] filterNames = { "Виробник", "Діагональ екрана", "Процесор" };
            foreach (var type in filterNames)
            {
                if (context.FilterNames.SingleOrDefault(f => f.Name == type) == null)
                {
                    context.FilterNames.Add(
                        new FilterName
                        {
                            Name = type
                        });
                    context.SaveChanges();
                }
            }
            #endregion

            #region tblFilterValues - Значення фільтрів
            List<string[]> filterValues = new List<string[]> {
                new string [] { "HP", "Dell", "Apple" },
                new string [] { "13\"", "14\"", "15\"-15.6\"", "16\"-17\"" },
                new string [] { "Intel Core i5", "Intel Core i7", "AMD Ryzen 9" }
            };

            foreach (var items in filterValues)
            {
                foreach (var value in items)
                {
                    if (context.FilterValues
                        .SingleOrDefault(f => f.Name == value) == null)
                    {
                        context.FilterValues.Add(
                            new FilterValue
                            {
                                Name = value
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            #region Групування фільтрів

            for (int i = 0; i < filterNames.Length; i++)
            {
                foreach (var value in filterValues[i])
                {
                    var nId = context.FilterNames
                        .SingleOrDefault(ben => ben.Name == filterNames[i]).Id;
                    var vId = context.FilterValues
                        .SingleOrDefault(f => f.Name == value).Id;
                    if (context.FilterNameGroups
                        .SingleOrDefault(f => f.FilterValueId == vId &&
                        f.FilterNameId == nId) == null)
                    {
                        context.FilterNameGroups.Add(
                            new FilterNameGroup
                            {
                                FilterNameId = nId,
                                FilterValueId = vId
                            });
                        context.SaveChanges();
                    }
                }
            }

            #endregion
        
        
        }


        #endregion
    }
}
