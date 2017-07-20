using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (this.Database.EnsureCreated())
            {
                this.Roles.Add(new Role() { Name = "Admin", Permission = "" });
                this.Roles.Add(new Role() { Name = "Lecturer", Permission = "" });
                this.Roles.Add(new Role() { Name = "User", Permission = "" });
                this.Roles.Add(new Role() { Name = "Student", Permission = "" });

                this.SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ExamAttempt>().HasOne(x => x.Exam).WithMany(z => z.ExamAttempts).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Mistake>().HasOne(x => x.Argument).WithMany(z => z.Mistakes).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<ArgumentCriterea>().HasOne(x => x.GeneralCriterea).WithMany(z => z.ArgumentCritereas).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Exam>().HasOne(x => x.Course).WithMany(z => z.Exams).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Censor>().HasOne(x => x.User).WithMany(z => z.Censors).OnDelete(DeleteBehavior.Restrict);
        }

        public virtual DbSet<Advice> Advices { get; set; }
        public virtual DbSet<Anwser> Anwsers { get; set; }
        public virtual DbSet<Censor> Censors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<GeneralCriterea> GeneralCriterea { get; set; }
        public virtual DbSet<GeneralCritereaImpact> GeneralCritereaImpacts { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamAdvice> ExamAdvices { get; set; }
        public virtual DbSet<ExamAttempt> ExamAttempts { get; set; }
        public virtual DbSet<Argument> Arguments { get; set; }
        public virtual DbSet<ArgumentCriterea> ArgumentCritereas { get; set; }
        public virtual DbSet<Mistake> Mistakes { get; set; }
        public virtual DbSet<Qestion> Qestions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }


    }
}