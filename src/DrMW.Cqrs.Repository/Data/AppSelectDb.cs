using DrMW.Cqrs.Core.Edu;
using DrMW.Cqrs.Core.Edu.Questionnaires;
using DrMW.Cqrs.Core.Students;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Repository.Data;

public class AppSelectDb : DbContext
{
    
    #region Students
    public DbSet<Student> Students { get; set; }
    //public DbSet<Detail> StudentDetails { get; set; }
    public DbSet<Status> StudentStatus { get; set; } 
    #endregion
   
    #region Edu

    #region Quest

    public DbSet<EduLevel> EducationLevels { get; set; }
    public DbSet<EduType> EducationTypes { get; set; }

    #endregion
    
    public DbSet<Group> Groups { get; set; }
    public DbSet<Subject> Subjects { get; set; } 
    public DbSet<GroupSubject> GroupSubjects { get; set; }
    #endregion
    

    public AppSelectDb(DbContextOptions<AppSelectDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(s => s.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Detail)
            .WithOne(s => s.Student)
            .HasForeignKey<Detail>(s => s.Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.ApplyDbSeedData();
    }
}