namespace UniversityWebDBMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UniModel : DbContext
    {
        public UniModel()
            : base("name=UniModel1")
        {
        }

        public virtual DbSet<AcademicInfo> AcademicInfos { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<LoginCredential> LoginCredentials { get; set; }
        public virtual DbSet<LoginInfo> LoginInfoes { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<program_course_rel> program_course_rel { get; set; }
        public virtual DbSet<stud_course_rel> stud_course_rel { get; set; }
        public virtual DbSet<stud_prog_rel> stud_prog_rel { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicInfo>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<AcademicInfo>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<AcademicInfo>()
                .Property(e => e.advisor)
                .IsUnicode(false);

            modelBuilder.Entity<AcademicInfo>()
                .Property(e => e.dis_topic)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.program)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.program_course_rel)
                .WithOptional(e => e.Course1)
                .HasForeignKey(e => e.course);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.stud_course_rel)
                .WithOptional(e => e.Course1)
                .HasForeignKey(e => e.course);

            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<LoginCredential>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<LoginCredential>()
                .HasOptional(e => e.LoginInfo)
                .WithRequired(e => e.LoginCredential);

            modelBuilder.Entity<LoginCredential>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.LoginCredential);

            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.sessionid)
                .IsUnicode(false);

            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.browser)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .Property(e => e.department)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Program1)
                .HasForeignKey(e => e.program);

            modelBuilder.Entity<Program>()
                .HasMany(e => e.program_course_rel)
                .WithOptional(e => e.Program1)
                .HasForeignKey(e => e.program);

            modelBuilder.Entity<Program>()
                .HasMany(e => e.stud_prog_rel)
                .WithOptional(e => e.Program1)
                .HasForeignKey(e => e.program);

            modelBuilder.Entity<Program>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Program1)
                .HasForeignKey(e => e.program);

            modelBuilder.Entity<program_course_rel>()
                .Property(e => e.program)
                .IsUnicode(false);

            modelBuilder.Entity<program_course_rel>()
                .Property(e => e.course)
                .IsUnicode(false);

            modelBuilder.Entity<stud_course_rel>()
                .Property(e => e.student)
                .IsUnicode(false);

            modelBuilder.Entity<stud_course_rel>()
                .Property(e => e.course)
                .IsUnicode(false);

            modelBuilder.Entity<stud_prog_rel>()
                .Property(e => e.student)
                .IsUnicode(false);

            modelBuilder.Entity<stud_prog_rel>()
                .Property(e => e.program)
                .IsUnicode(false);

            modelBuilder.Entity<stud_prog_rel>()
                .Property(e => e.gpa)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.program)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasOptional(e => e.AcademicInfo)
                .WithRequired(e => e.Student);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.stud_course_rel)
                .WithOptional(e => e.Student1)
                .HasForeignKey(e => e.student);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.stud_prog_rel)
                .WithOptional(e => e.Student1)
                .HasForeignKey(e => e.student);

            modelBuilder.Entity<User>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Student)
                .WithRequired(e => e.User);
        }
    }
}
