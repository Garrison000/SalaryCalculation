using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class DatabaseContext :DbContext
    {
        private static DatabaseContext context { get; set; }
        public static DatabaseContext GetInstance()
        {
            if(context==null)
            {
                context = new DatabaseContext();
            }
            return context;
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<SchoolClass> Classes { get; set; }
        public DbSet<Constants> Constants { get; set; }
        public DbSet<NameType> NameTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasKey(t => t.ID).HasMany(t => t.Lessons).WithRequired(o => o.Teacher);
            modelBuilder.Entity<Teacher>().HasMany(t => t.Activities).WithMany(o => o.Teachers);
            modelBuilder.Entity<Lesson>().HasKey(l => l.ID).HasRequired(o => o.Type).WithMany(o=> o.Lessons);
            modelBuilder.Entity<Lesson>().HasRequired(o => o.SchoolClass).WithMany(o => o.Lessons);
            modelBuilder.Entity<LessonType>().HasKey(l => l.ID);
            modelBuilder.Entity<Activity>().HasKey(a => a.ID).HasRequired(o=>o.Type).WithMany(o=>o.Activities);
            modelBuilder.Entity<ActivityType>().HasKey(a => a.ID);
            modelBuilder.Entity<Constants>().HasKey(o => o.ID);
            modelBuilder.Entity<NameType>().HasKey(o => o.ID);
        }
    }


}
