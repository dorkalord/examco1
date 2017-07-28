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
                
                this.States.Add(new State() {Name = "Defining", Commads="['edit', 'exportExam']"});
                this.States.Add(new State() {Name = "Peer censoring", Commads="['censor']"});
                this.States.Add(new State() {Name = "Grading", Commads="['evaluate', 'exportExam', 'exportCensoring']"});
                this.States.Add(new State() {Name = "Closed", Commads="['exportExam', 'exportCensoring', 'exportEvaluations' 'generateStudentReports', ]"});

                this.Grades.Add(new Grade() { Name = "A", Top = 10F });
                this.Grades.Add(new Grade() { Name = "B", Top = 27.5F });
                this.Grades.Add(new Grade() { Name = "C", Top = 52.5F });
                this.Grades.Add(new Grade() { Name = "D", Top = 70F });
                this.Grades.Add(new Grade() { Name = "E", Top = 80F });
                this.Grades.Add(new Grade() { Name = "F", Top = 100F });
                this.SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Tag>().HasOne(x => x.Topic).WithMany(t => t.Tags).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<ExamAttempt>().HasOne(x => x.Exam).WithMany(z => z.ExamAttempts).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Mistake>().HasOne(x => x.Argument).WithMany(z => z.Mistakes).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<ArgumentCriterea>().HasOne(x => x.ExamCriterea).WithMany(z => z.ArgumentCritereas).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Exam>().HasOne(x => x.Course).WithMany(z => z.Exams).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Censor>().HasOne(x => x.User).WithMany(z => z.Censors).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Anwser>().HasOne(a => a.Question).WithMany(q => q.Anwsers).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<ExamAdvice>().HasOne(x => x.ExamCriterea).WithMany(q => q.ExamAdvices).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<GeneralCritereaImpact>().HasOne(x => x.ExamCriterea).WithMany(q => q.GeneralCritereaImpacts).OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Topic>().HasOne(t => t.ParrentTopic).WithMany(t => t.ChildTopics).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<State>().HasOne(s => s.Next).WithOne(n => n.Previous).HasForeignKey<State>(p => p.NextID);
            mb.Entity<State>().HasOne(s => s.Previous).WithOne(n => n.Next).HasForeignKey<State>(p => p.PreviousID);
        }

        public virtual DbSet<Advice> Advices { get; set; }
        public virtual DbSet<Anwser> Anwsers { get; set; }
        public virtual DbSet<Censor> Censors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<ExamCriterea> ExamCritereas { get; set; }
        public virtual DbSet<CourseCriterea> CourseCritereas { get; set; }
        public virtual DbSet<GeneralCriterea> GeneralCritereas { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<GeneralCritereaImpact> GeneralCritereaImpacts { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamAdvice> ExamAdvices { get; set; }
        public virtual DbSet<ExamAttempt> ExamAttempts { get; set; }
        public virtual DbSet<Argument> Arguments { get; set; }
        public virtual DbSet<ArgumentCriterea> ArgumentCritereas { get; set; }
        public virtual DbSet<Mistake> Mistakes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }


    }
}