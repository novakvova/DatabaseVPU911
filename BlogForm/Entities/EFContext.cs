using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogForm.Entities
{
    public class EFContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=dbblog;Username=userblog;Password=$544idkeuIDOKEKDds(Kdues9dfsuiio$B5rd@dddss542G)K$t!Ube22}xk");
        }
    }
}
