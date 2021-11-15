using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MidTermProject.Models
{
    public class MidtermDbContext : DbContext
    {
        public MidtermDbContext() : base("name=MidtermDbContext")
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

    }
}